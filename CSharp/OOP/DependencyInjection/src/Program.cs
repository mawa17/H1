using Microsoft.Extensions.DependencyInjection;

namespace src
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection();
            serviceProvider.AddScoped<DPServiceExample>();
            var provider = serviceProvider.BuildServiceProvider();

            new Startup(provider).Main();

        }
    }
}
