using InstaConnect.Identity.Business.Features.Accounts.Extensions;
using InstaConnect.Identity.Business.Features.Users.Extensions;
using InstaConnect.Identity.Web.Features.Accounts.Extensions;
using InstaConnect.Identity.Web.Features.Users.Extensions;
using InstaConnect.Shared.Business.Extensions;
using InstaConnect.Shared.Web.Extensions;

namespace InstaConnect.Identity.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddAccountServices(configuration)
            .AddUserServices();

        serviceCollection
            .AddJwtBearer(configuration)
            .AddApiControllers()
            .AddMapper(currentAssembly)
            .AddAuthorizationPolicies()
            .AddCorsPolicies(configuration)
            .AddSwagger()
            .AddRateLimiterPolicies()
            .AddVersioning()
            .AddCurrentUserContext()
            .AddExceptionHandler();

        serviceCollection.AddEndpointsApiExplorer();

        serviceCollection.ConfigureApiBehaviorOptions();

        return serviceCollection;
    }
}
