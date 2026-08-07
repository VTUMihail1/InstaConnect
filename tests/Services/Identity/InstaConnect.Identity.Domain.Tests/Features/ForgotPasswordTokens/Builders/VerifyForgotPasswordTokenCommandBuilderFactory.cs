namespace InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Builders;

public class VerifyForgotPasswordTokenCommandBuilderFactory
{
	public VerifyForgotPasswordTokenCommandBuilder Create(ForgotPasswordToken forgotPasswordToken)
	{
		return new(forgotPasswordToken);
	}
}
