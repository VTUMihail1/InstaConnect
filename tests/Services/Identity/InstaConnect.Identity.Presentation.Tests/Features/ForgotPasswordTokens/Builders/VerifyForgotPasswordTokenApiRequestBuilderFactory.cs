namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Builders;

public class VerifyForgotPasswordTokenApiRequestBuilderFactory
{
	public VerifyForgotPasswordTokenApiRequestBuilder Create(ForgotPasswordToken forgotPasswordToken)
	{
		return new(forgotPasswordToken);
	}
}
