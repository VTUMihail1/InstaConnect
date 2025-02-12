namespace InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Models;

public record GenerateForgotPasswordTokenResponse(string UserId, string Email, DateTime ValidUntil, string Value, string RedirectUrl);
