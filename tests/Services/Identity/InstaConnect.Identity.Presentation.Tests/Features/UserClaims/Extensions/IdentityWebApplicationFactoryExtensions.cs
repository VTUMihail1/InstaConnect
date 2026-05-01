using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.Common.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Extensions;

public static class IdentityWebApplicationFactoryExtensions
{
	extension(IdentityWebApplicationFactory webApplicationFactory)
	{
		public IUserClaimClient CreateUserClaimClient()
		{
			return new UserClaimClient(webApplicationFactory.CreateClient(), webApplicationFactory.Services.GetBaseAccessTokenGenerator());
		}
	}
}
