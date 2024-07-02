using InstaConnect.Shared.Web.Extensions;

namespace InstaConnect.Gateway.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddJwtBearer(configuration)
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
