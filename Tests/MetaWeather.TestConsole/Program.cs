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
            var resp1=await weather.GetWeatherByName("POLOCK", "1c90cb6e06b6e698cc56b446a618395b");
            var resp2 = await weather.GetWeatherByCoords((55.74, 37.67), "1c90cb6e06b6e698cc56b446a618395b");

            Console.WriteLine(resp1);
            Console.WriteLine(resp2);
            Console.WriteLine("Завершено");
            Console.ReadKey();

            await host.StopAsync();
        }
    }
}