using InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Common.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Extensions;

public static class IdentityWebApplicationFactoryExtensions
{
	extension(IdentityWebApplicationFactory webApplicationFactory)
	{
		public IEmailConfirmationTokenClient CreateEmailConfirmationTokenClient()
		{
			return new EmailConfirmationTokenClient(webApplicationFactory.CreateClient());
		}
	}
}
