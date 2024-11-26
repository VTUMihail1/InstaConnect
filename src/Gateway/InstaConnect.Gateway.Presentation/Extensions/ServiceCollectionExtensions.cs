using InstaConnect.Shared.Web.Extensions;

namespace InstaConnect.Gateway.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddAuthorizationPolicies()
            .AddCorsPolicies(configuration)
            .AddRateLimiterPolicies()
            .AddSwagger();

        serviceCollection
            .AddReverseProxy()
            .LoadFromConfig(configuration.GetSection("ReverseProxy"));

        return serviceCollection;
    }
}
