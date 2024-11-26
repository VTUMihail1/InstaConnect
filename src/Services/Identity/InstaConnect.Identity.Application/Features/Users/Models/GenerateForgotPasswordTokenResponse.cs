namespace InstaConnect.Identity.Application.Features.Users.Models;

public record GenerateForgotPasswordTokenResponse(string UserId, string Email, DateTime ValidUntil, string Value, string RedirectUrl);
