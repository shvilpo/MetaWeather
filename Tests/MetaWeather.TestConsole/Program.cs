using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddHttpClient<MetaWeatherClient>(client => 
                client.BaseAddress = new Uri(host.Configuration["source"]));
        }

        static async Task Main(string[] args)
        {
            using IHost? host = Hosting;
            await host.StartAsync();

            var weather = Services.GetRequiredService<MetaWeatherClient>();
            var resp=await weather.GetWeather("POLOCK", "1c90cb6e06b6e698cc56b446a618395b");
            Console.WriteLine("Завершено");
            Console.ReadKey();

            await host.StopAsync();
        }
    }
}