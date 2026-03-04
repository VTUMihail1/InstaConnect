namespace InstaConnect.Identity.Domain.Models.Requests;

public enum IdentityDestinationType
{
    None,
    User,
    UserClaim,
    RefreshToken,
    ForgotPasswordToken,
    EmailConfirmationToken
}
