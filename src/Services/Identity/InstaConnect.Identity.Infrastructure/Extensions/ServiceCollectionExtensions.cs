using InstaConnect.Common.Extensions;
using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;
using InstaConnect.Identity.Infrastructure.Features.Users.Extensions;
using InstaConnect.Shared.Infrastructure.Extensions;

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
            .AddForgotPasswordTokenServices()
            .AddEmailConfirmationTokenServices()
            .AddUserClaimServices()
            .AddUserServices();

        serviceCollection
            .AddObservability(configuration, webHostEnvironment)
            .AddDatabaseContext<IdentityContext>(configuration)
            .AddServicesWithMatchingInterfaces(InfrastructureReference.Assembly)
            .AddRedisCaching(configuration)
            .AddUnitOfWork<IdentityContext>()
            .AddJwtBearer(configuration)
            .AddCloudinary(configuration)
            .AddRabbitMQ(configuration, InfrastructureReference.Assembly, busConfigurator =>
                busConfigurator.AddTransactionalOutbox<IdentityContext>())
            .AddDateTimeProvider();

        return serviceCollection;
    }
}
