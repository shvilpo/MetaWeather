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
        private static void ConfigureServices(HostBuilderContext arg1, IServiceCollection arg2)
        { 
        
        }

        static async Task Main(string[] args)
        {
            using IHost? host = Hosting;
            await host.StartAsync();

            Console.WriteLine("Завершено");
            Console.ReadLine();

            await host.StopAsync();
        }
    }
}