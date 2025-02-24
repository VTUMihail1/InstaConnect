namespace InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Models;

public record GenerateEmailConfirmationTokenResponse(string UserId, string Email, DateTimeOffset ValidUntil, string Value, string RedirectUrl);
