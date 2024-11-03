namespace InstaConnect.Identity.Business.Features.Users.Models;

public record GenerateForgotPasswordTokenResponse(string UserId, string Email, DateTime ValidUntil, string Value, string RedirectUrl);
