using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Data.Features.UserClaims.Extensions;
using InstaConnect.Identity.Data.Features.Users.Extensions;
using InstaConnect.Identity.Data.Helpers;
using InstaConnect.Shared.Data.Abstractions;
using InstaConnect.Shared.Data.Extensions;
using InstaConnect.Shared.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Data.Extensions;

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
            .AddCaching(configuration)
            .AddUnitOfWork<IdentityContext>()
            .AddJwtBearer(configuration)
            .AddImageHandler(configuration)
            .AddMessageBroker(configuration, currentAssembly, busConfigurator =>
                busConfigurator.AddTransactionalOutbox<IdentityContext>());

        return serviceCollection;
    }
}
