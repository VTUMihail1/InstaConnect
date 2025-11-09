namespace InstaConnect.Identity.Domain.Features.Users.Models.Requests;

public enum UserIncludeProperty
{
    None,
    Claims,
    EmailConfirmationTokens,
    ForgotPasswordTokens,
    RefreshTokens
}
