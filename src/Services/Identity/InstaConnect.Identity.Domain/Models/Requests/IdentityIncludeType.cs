namespace InstaConnect.Identity.Domain.Models.Requests;

public enum IdentityIncludeType
{
    None,
    User,
    UserClaim,
    RefreshToken,
    ForgotPasswordToken,
    EmailConfirmationToken
}
