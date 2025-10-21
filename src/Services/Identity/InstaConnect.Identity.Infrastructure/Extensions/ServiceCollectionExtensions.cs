using InstaConnect.Common.Extensions;
using InstaConnect.EmailConfirmationTokens.Infrastructure.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.ForgotPasswordTokens.Infrastructure.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.RefreshTokens.Infrastructure.Features.RefreshTokens.Extensions;
using InstaConnect.Shared.Infrastructure.Extensions;
using InstaConnect.UserClaims.Infrastructure.Features.UserClaims.Extensions;
using InstaConnect.Users.Infrastructure.Features.Users.Extensions;

using Microsoft.AspNetCore.Hosting;

namespace InstaConnect.Users.Infrastructure.Extensions;

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
            .AddDateTimeProvider();

        return serviceCollection;
    }
}
