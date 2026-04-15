namespace InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Builders;

public class VerifyForgotPasswordTokenCommandRequestBuilderFactory
{
    public VerifyForgotPasswordTokenCommandRequestBuilder Create(ForgotPasswordToken forgotPasswordToken)
    {
        return new(forgotPasswordToken);
    }
}
