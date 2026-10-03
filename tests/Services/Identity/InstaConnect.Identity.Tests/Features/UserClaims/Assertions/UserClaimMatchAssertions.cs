using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Assertions;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Tests.Features.UserClaims.Assertions;

public static class UserClaimMatchAssertions
{
	extension(UserClaim u)
	{
		public void ShouldSatisfy(UserClaim userClaim)
		{
			u.ShouldSatisfy(u => u.Matches(userClaim));
		}
	}
}
