using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection serviceCollection)
        {
            return serviceCollection;
        }
    }
}
