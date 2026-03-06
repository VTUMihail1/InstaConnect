using InstaConnect.Common.Presentation.Extensions;

namespace InstaConnect.Gateway.Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddPresentation(IConfiguration configuration)
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
}
