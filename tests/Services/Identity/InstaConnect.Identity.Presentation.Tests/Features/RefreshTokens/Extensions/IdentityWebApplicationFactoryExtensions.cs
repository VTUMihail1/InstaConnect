using InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Common.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Extensions;

public static class IdentityWebApplicationFactoryExtensions
{
	extension(IdentityWebApplicationFactory webApplicationFactory)
	{
		public IRefreshTokenClient CreateRefreshTokenClient()
		{
			return new RefreshTokenClient(webApplicationFactory.CreateClient());
		}
	}
}
