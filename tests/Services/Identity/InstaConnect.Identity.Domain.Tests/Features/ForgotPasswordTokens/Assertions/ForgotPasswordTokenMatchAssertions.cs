using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenMatchAssertions
{
	extension(ForgotPasswordTokenId response)
	{
		public void ShouldSatisfy(AddForgotPasswordTokenCommand command, ForgotPasswordToken forgotPasswordToken)
		{
			response.ShouldSatisfy(p => p.Matches(command, forgotPasswordToken));
		}
	}

	extension(User user)
	{
		public void ShouldSatisfy(VerifyForgotPasswordTokenCommand command, IPasswordHasher passwordHasher)
		{
			user.ShouldSatisfy(p => p.Matches(command, passwordHasher));
		}
	}
}
