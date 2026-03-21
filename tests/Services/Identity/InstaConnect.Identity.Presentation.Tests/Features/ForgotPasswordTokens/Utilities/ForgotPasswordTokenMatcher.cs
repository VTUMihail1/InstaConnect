namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenMatcher
{
    public static AddForgotPasswordTokenCommandRequest IsAddForgotPasswordTokenCommandRequest(AddForgotPasswordTokenApiRequest request)
    {
        return Matcher.Is<AddForgotPasswordTokenCommandRequest>(p => p.Matches(request));
    }

    public static VerifyForgotPasswordTokenCommandRequest IsVerifyForgotPasswordTokenCommandRequest(VerifyForgotPasswordTokenApiRequest request)
    {
        return Matcher.Is<VerifyForgotPasswordTokenCommandRequest>(p => p.Matches(request));
    }
}
