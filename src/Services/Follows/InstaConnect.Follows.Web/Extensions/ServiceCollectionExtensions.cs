using InstaConnect.Follows.Business.Features.Follows.Extensions;
using InstaConnect.Follows.Web.Features.Follows.Extensions;
using InstaConnect.Follows.Web.Features.Users.Extensions;
using InstaConnect.Shared.Web.Extensions;

namespace InstaConnect.Follows.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddFollowServices()
            .AddUserServices();

        serviceCollection
            .AddJwtBearer(configuration)
            .AddApiControllers()
            .AddAutoMapper(currentAssembly)
            .AddAuthorizationPolicies()
            .AddCorsPolicies(configuration)
            .AddSwagger()
            .AddRateLimiterPolicies()
            .AddVersioning()
            .AddCurrentUserContext()
            .AddExceptionHandler();

        serviceCollection.ConfigureApiBehaviorOptions();

        return serviceCollection;
    }
}
