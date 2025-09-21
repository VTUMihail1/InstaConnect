using InstaConnect.Common.Extensions;
using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.EmailConfirmationTokens.Infrastructure.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.ForgotPasswordTokens.Infrastructure.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;
using InstaConnect.Identity.Infrastructure.Features.Users.Extensions;
using InstaConnect.RefreshTokens.Infrastructure.Features.RefreshTokens.Extensions;
using InstaConnect.Shared.Infrastructure.Extensions;
using InstaConnect.UserClaims.Infrastructure.Features.UserClaims.Extensions;
using InstaConnect.Users.Infrastructure.Features.Users.Extensions;

using Microsoft.AspNetCore.Hosting;

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
            .AddDatabaseContext<IdentityContext>(configuration)
            .AddServicesWithMatchingInterfaces(IdentityInfrastructureReference.Assembly)
            .AddRedisCaching(configuration)
            .AddUnitOfWork<IdentityContext>()
            .AddJwtBearer(configuration)
            .AddCloudinary(configuration)
            .AddRabbitMQ(configuration, IdentityInfrastructureReference.Assembly, busConfigurator =>
                busConfigurator.AddTransactionalOutbox<IdentityContext>())
            .AddDateTimeProvider();

        return serviceCollection;
    }
}
