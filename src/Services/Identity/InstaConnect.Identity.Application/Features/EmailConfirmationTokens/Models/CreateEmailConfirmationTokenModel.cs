namespace InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Models;

public record CreateEmailConfirmationTokenModel(string UserId, string Email);
