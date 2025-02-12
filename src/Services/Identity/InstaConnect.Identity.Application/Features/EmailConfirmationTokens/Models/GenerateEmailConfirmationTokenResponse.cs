namespace InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Models;

public record GenerateEmailConfirmationTokenResponse(string UserId, string Email, DateTime ValidUntil, string Value, string RedirectUrl);
