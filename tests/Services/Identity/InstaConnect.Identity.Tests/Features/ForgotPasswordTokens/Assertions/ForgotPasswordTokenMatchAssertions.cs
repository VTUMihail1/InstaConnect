using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Assertions;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Assertions;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenMatchAssertions
{
	extension(ICollection<ForgotPasswordToken> forgotPasswordTokens)
	{
		public void ShouldSatisfy(ICollection<ForgotPasswordToken> f)
		{
			forgotPasswordTokens.ShouldSatisfy(p => p.Matches(f));
		}
	}
}
