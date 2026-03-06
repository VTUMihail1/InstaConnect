using System.Reflection;

using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;
using InstaConnect.Identity.Infrastructure.Features.Users.Extensions;

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
                .AddRabbitMQ(configuration, presentationAssembly)
                .AddJwtBearer(configuration)
                .AddGuidProvider()
                .AddDateTimeProvider()
                .AddSortOrders();

            return serviceCollection;
        }
    }
}
