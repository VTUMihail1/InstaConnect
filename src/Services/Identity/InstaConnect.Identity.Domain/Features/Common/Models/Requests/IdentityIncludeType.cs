namespace InstaConnect.Identity.Domain.Features.Common.Models.Requests;

public enum IdentityIncludeType
{
    None,
    User,
    UserClaim,
    RefreshToken,
    ForgotPasswordToken,
    EmailConfirmationToken
}
