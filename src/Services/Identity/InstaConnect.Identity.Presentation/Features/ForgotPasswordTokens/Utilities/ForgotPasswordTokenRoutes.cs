namespace InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Utilities;

public class ForgotPasswordTokenRoutes
{
    public const string Resource = "api/v{version:apiVersion}/users";

    public const string Add = "{email}/forgot-password-tokens";
    public const string Verify = "{userId}/forgot-password-tokens/{token}/verify";

    public const string Version1 = "1.0";
}
