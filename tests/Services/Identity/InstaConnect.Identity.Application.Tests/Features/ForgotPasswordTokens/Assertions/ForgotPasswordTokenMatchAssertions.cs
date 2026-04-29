using InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Domain.Features.Common.Helpers;

namespace InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenMatchAssertions
{
	extension(ForgotPasswordToken forgotPasswordToken)
	{
		public void ShouldSatisfy(AddForgotPasswordTokenCommandRequest request)
		{
			forgotPasswordToken.ShouldSatisfy(p => p.Matches(request));
		}

		public void ShouldSatisfy(VerifyForgotPasswordTokenCommandRequest request, IPasswordHasher passwordHasher)
		{
			forgotPasswordToken.ShouldSatisfy(p => p.Matches(request, passwordHasher));
		}
	}
}
