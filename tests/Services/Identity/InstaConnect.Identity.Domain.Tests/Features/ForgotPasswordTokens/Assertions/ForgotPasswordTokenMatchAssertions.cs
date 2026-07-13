using InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenMatchAssertions
{
	extension(ForgotPasswordTokenId response)
	{
		public void ShouldSatisfy(ForgotPasswordToken forgotPasswordToken, AddForgotPasswordTokenCommand command)
		{
			response.ShouldSatisfy(p => p.Matches(forgotPasswordToken, command));
		}
	}
}
