namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenReference
{
	extension(ForgotPasswordToken? forgotPasswordToken)
	{
		public ForgotPasswordToken? SetUser()
		{
			forgotPasswordToken?.User?.AddForgotPasswordToken(forgotPasswordToken);

			return forgotPasswordToken;
		}
	}
}
