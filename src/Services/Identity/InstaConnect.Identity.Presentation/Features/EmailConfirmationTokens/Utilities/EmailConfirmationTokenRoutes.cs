namespace InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenRoutes
{
    public const string Version1 = "1.0";
    public const string Resource = "api/v{version:apiVersion}/users";
    public const string Add = "{email}/email-confirmation-tokens";
    public const string Verify = "{userId}/email-confirmation-tokens/{token}/verify";
}
