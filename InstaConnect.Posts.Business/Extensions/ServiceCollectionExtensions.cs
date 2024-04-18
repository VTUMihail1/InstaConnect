using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection serviceCollection)
        {
            return serviceCollection;
        }
    }
}
