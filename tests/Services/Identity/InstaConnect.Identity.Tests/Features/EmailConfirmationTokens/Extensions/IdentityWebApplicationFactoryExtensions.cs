using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Helpers;
using InstaConnect.Identity.Tests.Features.Common.Utilities;

namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Extensions;

public static class IdentityWebApplicationFactoryExtensions
{
	extension(IdentityWebApplicationFactory webApplicationFactory)
	{
		public IEmailConfirmationTokenEventClient CreateEmailConfirmationTokenEventClient()
		{
			var eventClient = webApplicationFactory.Services.GetEventClient();

			return new EmailConfirmationTokenEventClient(eventClient);
		}
	}
}
