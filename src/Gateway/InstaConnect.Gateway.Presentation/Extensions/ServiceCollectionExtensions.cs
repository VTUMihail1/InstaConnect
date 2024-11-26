using InstaConnect.Shared.Presentation.Extensions;

namespace InstaConnect.Gateway.Presentation.Extensions;

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
