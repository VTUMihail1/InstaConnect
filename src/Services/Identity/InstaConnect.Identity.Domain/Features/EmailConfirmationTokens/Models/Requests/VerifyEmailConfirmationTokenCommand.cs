namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;

public record VerifyEmailConfirmationTokenCommand(string Id, string Value);
