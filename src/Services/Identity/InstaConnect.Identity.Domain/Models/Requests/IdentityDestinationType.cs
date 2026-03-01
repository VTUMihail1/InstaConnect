namespace InstaConnect.Identity.Domain.Models.Requests;

public enum IdentityDestinationType
{
    None,
    Users,
    UserClaims,
    RefreshTokens,
    ForgotPasswordTokens,
    EmailConfirmationTokens
}
