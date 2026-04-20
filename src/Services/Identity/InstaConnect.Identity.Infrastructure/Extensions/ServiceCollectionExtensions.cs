using System.Reflection;

using InstaConnect.Identity.Domain.Helpers;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;
using InstaConnect.Identity.Infrastructure.Features.Users.Extensions;
using InstaConnect.Identity.Infrastructure.Helpers;
using InstaConnect.Identity.Infrastructure.Utilities;

namespace InstaConnect.Identity.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddInfrastructure(
            IConfiguration configuration,
            IWebHostEnvironment webHostEnvironment,
            Assembly presentationAssembly)
        {
            serviceCollection.AddSingleton<IPasswordHasher, PasswordHasher>();

            serviceCollection
                .AddUserServices()
                .AddUserClaimServices()
                .AddRefreshTokenServices()
                .AddForgotPasswordTokenServices()
                .AddEmailConfirmationTokenServices();

            serviceCollection
                .AddOpenTelemetry(configuration, webHostEnvironment)
                .AddMapper(IdentityInfrastructureReference.Assembly)
                .AddServicesWithMatchingInterfaces(IdentityInfrastructureReference.Assembly)
                .AddRedisCaching(configuration)
                .AddMongoDatabase(configuration)
                .AddCloudinary(configuration)
                .AddUnitOfWork()
                .AddRabbitMQ(configuration, IdentityEventHandlerUtilities.Prefix, presentationAssembly)
                .AddJwtBearer(configuration)
                .AddGuidProvider()
                .AddDateTimeProvider()
                .AddSortOrders();

            return serviceCollection;
        }
    }
}
