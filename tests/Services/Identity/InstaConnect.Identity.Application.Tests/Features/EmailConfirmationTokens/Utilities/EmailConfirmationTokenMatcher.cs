namespace InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenMatcher
{
    public static AddEmailConfirmationTokenCommand IsAddEmailConfirmationTokenCommand(AddEmailConfirmationTokenCommandRequest request)
    {
        return Matcher.Is<AddEmailConfirmationTokenCommand>(p => p.Matches(request));
    }

    public static VerifyEmailConfirmationTokenCommand IsVerifyEmailConfirmationTokenCommand(VerifyEmailConfirmationTokenCommandRequest request)
    {
        return Matcher.Is<VerifyEmailConfirmationTokenCommand>(p => p.Matches(request));
    }
}
