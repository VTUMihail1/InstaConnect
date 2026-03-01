namespace InstaConnect.Identity.Domain.Models.Requests;

public enum IdentityIncludeType
{
    None,
    Users,
    UserClaims,
    RefreshTokens,
    ForgotPasswordTokens,
    EmailConfirmationTokens
}
