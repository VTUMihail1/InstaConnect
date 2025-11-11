using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;
using InstaConnect.Identity.Infrastructure.Features.Users.Extensions;

namespace InstaConnect.Identity.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection serviceCollection,
        IConfiguration configuration,
        IWebHostEnvironment webHostEnvironment)
    {
        serviceCollection
            .AddUserServices()
            .AddUserClaimServices()
            .AddRefreshTokenServices()
            .AddForgotPasswordTokenServices()
            .AddEmailConfirmationTokenServices();

        serviceCollection
            .AddObservability(configuration, webHostEnvironment)
            .AddMapper(IdentityInfrastructureReference.Assembly)
            .AddServicesWithMatchingInterfaces(IdentityInfrastructureReference.Assembly)
            .AddMongoDbContext()
            .AddUnitOfWork()
            .AddRabbitMQ(configuration, IdentityInfrastructureReference.Assembly)
            .AddJwtBearer(configuration)
            .AddGuidProvider()
            .AddDateTimeProvider()
            .AddSortOrders();

        return serviceCollection;
    }
}
