using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection serviceCollection)
        {
            return serviceCollection;
        }
    }
}
