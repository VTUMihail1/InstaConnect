using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenMatchAssertions
{
	extension(ForgotPasswordToken forgotPasswordToken)
	{
		public void ShouldSatisfy(AddForgotPasswordTokenApiRequest request)
		{
			forgotPasswordToken.ShouldSatisfy(p => p.Matches(request));
		}

		public void ShouldSatisfy(VerifyForgotPasswordTokenApiRequest request, IPasswordHasher passwordHasher)
		{
			forgotPasswordToken.ShouldSatisfy(p => p.Matches(request, passwordHasher));
		}
	}
}
