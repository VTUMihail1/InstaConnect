using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;
using InstaConnect.Identity.Infrastructure.Features.Users.Extensions;
using InstaConnect.Identity.Infrastructure.Helpers;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var currentAssembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection
            .AddForgotPasswordTokenServices()
            .AddEmailConfirmationTokenServices()
            .AddUserClaimServices()
            .AddUserServices();

        serviceCollection
            .AddDatabaseContext<IdentityContext>(configuration);

        serviceCollection
            .AddScoped<IDatabaseSeeder, DatabaseSeeder>()
            .AddRedisCaching(configuration)
            .AddUnitOfWork<IdentityContext>()
            .AddJwtBearer(configuration)
            .AddCloudinary(configuration)
            .AddRabbitMQ(configuration, currentAssembly, busConfigurator =>
                busConfigurator.AddTransactionalOutbox<IdentityContext>())
            .AddDateTimeProvider();

        return serviceCollection;
    }
}
