using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using Polly.Extensions.Http;

namespace MetaWeather.TestConsole
{
    class Program
    {
        private static IHost __Hosting;
        public static IHost Hosting => __Hosting ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
        public static IServiceProvider Services => Hosting.Services;
        public static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureServices(ConfigureServices);
        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddHttpClient<WorldWeatherClient>(client =>
                    client.BaseAddress = new Uri(host.Configuration["source"]))
                .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                .AddPolicyHandler(GetRetryPolicy());
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            var jitter = new Random();

            return HttpPolicyExtensions.HandleTransientHttpError()
                .WaitAndRetryAsync(5, retry_attempt => 
                                                    TimeSpan.FromSeconds(Math.Pow(2,retry_attempt))
                                                    + TimeSpan.FromSeconds(jitter.Next(0, 1000)));
        }

        static async Task Main(string[] args)
        {
            using IHost? host = Hosting;
            await host.StartAsync();

            var weather = Services.GetRequiredService<WorldWeatherClient>();
            var resp1=await weather.GetWeatherByNameDate("Москва", new DateTime(2022,6,20), "1b0960d943584b59a6e65137222106");

            Console.WriteLine(resp1);
            Console.WriteLine("Завершено");
            Console.ReadKey();

            await host.StopAsync();
        }
    }
}