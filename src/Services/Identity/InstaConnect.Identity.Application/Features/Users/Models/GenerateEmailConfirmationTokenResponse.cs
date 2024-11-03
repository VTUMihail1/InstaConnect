namespace InstaConnect.Identity.Business.Features.Users.Models;

public record GenerateEmailConfirmationTokenResponse(string UserId, string Email, DateTime ValidUntil, string Value, string RedirectUrl);
