namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenReference
{
	extension(ICollection<ForgotPasswordToken> forgotPasswordTokens)
	{
		public ICollection<ForgotPasswordToken> SetUser()
		{
			foreach (var forgotPasswordToken in forgotPasswordTokens)
			{
				forgotPasswordToken.SetUser();
			}

			return forgotPasswordTokens;
		}
	}

	extension(ForgotPasswordToken? forgotPasswordToken)
	{
		public ForgotPasswordToken? SetUser()
		{
			forgotPasswordToken?.User?.AddForgotPasswordToken(forgotPasswordToken);

			return forgotPasswordToken;
		}
	}
}
