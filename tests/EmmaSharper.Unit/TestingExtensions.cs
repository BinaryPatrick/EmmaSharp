using Microsoft.Extensions.DependencyInjection;

namespace EmmaSharper.Unit
{
    public static class TestingExtensions
    {
        public static IServiceCollection GetBaseServices()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddLogging();

            return services;
        }
    }
}
