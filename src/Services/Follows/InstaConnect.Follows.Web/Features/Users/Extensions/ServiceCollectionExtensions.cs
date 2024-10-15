using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Web.Features.Users.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUserServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}
