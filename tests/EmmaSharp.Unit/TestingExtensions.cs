using Microsoft.Extensions.DependencyInjection;

namespace EmmaSharp.Unit
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
