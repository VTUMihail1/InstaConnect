using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenMapper
{
	extension(ForgotPasswordToken forgotPasswordToken)
	{
		public ForgotPasswordTokenId ToId(
)
		{
			return forgotPasswordToken.Id;
		}
	}
}
