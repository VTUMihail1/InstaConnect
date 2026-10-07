using System.Reflection;

using InstaConnect.Common.Domain.Features.Mappers.Extensions;
using InstaConnect.Common.Infrastructure.Features.AccessTokens.Extensions;
using InstaConnect.Common.Infrastructure.Features.Caches.Extensions;
using InstaConnect.Common.Infrastructure.Features.DateTimes.Extensions;
using InstaConnect.Common.Infrastructure.Features.Emails.Extensions;
using InstaConnect.Common.Infrastructure.Features.Events.Extensions;
using InstaConnect.Common.Infrastructure.Features.Guids.Extensions;
using InstaConnect.Common.Infrastructure.Features.Images.Extensions;
using InstaConnect.Common.Infrastructure.Features.Seeders.Extensions;
using InstaConnect.Common.Infrastructure.Features.Telemetries.Extensions;
using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Infrastructure.Features.Common.Helpers;
using InstaConnect.Identity.Infrastructure.Features.Common.Models.Options;
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
			serviceCollection.AddValidatedOptions<AdminOptions, AdminOptionsValidator>(AdminOptions.SectionName);

			serviceCollection.AddSingleton<IPasswordHasher, PasswordHasher>();

			serviceCollection
				.AddUserServices()
				.AddUserClaimServices()
				.AddRefreshTokenServices()
				.AddForgotPasswordTokenServices()
				.AddEmailConfirmationTokenServices();

			serviceCollection
				.AddTelemetries(configuration, webHostEnvironment)
				.AddMappers(IdentityInfrastructureReference.Assembly)
				.AddEmailSenders(configuration)
				.AddServicesWithMatchingInterfacesExceptFluents(IdentityInfrastructureReference.Assembly)
				.AddCaches(configuration)
				.AddDatabases(configuration)
				.AddSeeders<IIdentityDatabaseSeeder>()
				.AddImages(configuration)
				.AddEvents(configuration, IdentityEventHandlerUtilities.Prefix, presentationAssembly)
				.AddAccessTokens(configuration)
				.AddGuids()
				.AddDateTimes()
				.AddDatabaseSortOrders();

			return serviceCollection;
		}
	}
}
