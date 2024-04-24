using InstaConnect.Follows.Business.Profiles;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWebLayer(this IServiceCollection serviceCollection)
        {
            return serviceCollection;
        }
    }
}
