namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenTestRoutes
{
    public const string Add = "api/v1/users/{0}/forgot-password-tokens";
    public const string Verify = "api/v1/users/{0}/forgot-password-tokens/{1}/verify";
}
