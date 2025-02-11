namespace InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenTestRoutes
{
    public const string Add = "api/v1/users/{0}/email-confirmation-tokens";
    public const string Verify = "api/v1/users/{0}/email-confirmation-tokens/{1}/verify";
}
