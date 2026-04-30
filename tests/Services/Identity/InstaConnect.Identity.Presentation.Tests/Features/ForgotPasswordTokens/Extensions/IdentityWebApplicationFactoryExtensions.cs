using InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Common.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Extensions;

public static class IdentityWebApplicationFactoryExtensions
{
	extension(IdentityWebApplicationFactory webApplicationFactory)
	{
		public IForgotPasswordTokenClient CreateForgotPasswordTokenClient()
		{
			return new ForgotPasswordTokenClient(webApplicationFactory.CreateClient());
		}
	}
}
