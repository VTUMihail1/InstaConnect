namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Helpers;

public class ForgotPasswordTokenIncludeBuilderFactory : IForgotPasswordTokenIncludeBuilderFactory
{
    public ForgotPasswordTokenIncludeBuilder Create()
    {
        return new ForgotPasswordTokenIncludeBuilder([]);
    }
}
