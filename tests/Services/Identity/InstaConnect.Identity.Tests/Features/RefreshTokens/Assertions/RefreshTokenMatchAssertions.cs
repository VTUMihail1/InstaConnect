using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Assertions;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Assertions;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenMatchAssertions
{
	extension(RefreshToken u)
	{
		public void ShouldSatisfy(RefreshToken refreshToken)
		{
			u.ShouldSatisfy(u => u.Matches(refreshToken));
		}
	}
}
