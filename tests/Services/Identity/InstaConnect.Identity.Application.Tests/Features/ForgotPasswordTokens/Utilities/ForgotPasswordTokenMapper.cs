namespace InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenMapper
{
	extension(ForgotPasswordToken forgotPasswordToken)
	{
		internal ForgotPasswordTokenId ToIdResponse()
		{
			return forgotPasswordToken.Id;
		}

		public ForgotPasswordTokenId ToResponse(
			AddForgotPasswordTokenCommandRequest request)
		{
			return forgotPasswordToken.ToIdResponse();
		}
	}
}
