using System.Reflection;

using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Infrastructure.Features.Common.Helpers;
using InstaConnect.Identity.Infrastructure.Features.Common.Utilities;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;
using InstaConnect.Identity.Infrastructure.Features.Users.Extensions;

namespace InstaConnect.Identity.Infrastructure.Features.Common.Extensions;

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
                .AddRedis(configuration)
                .AddMongo(configuration)
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
