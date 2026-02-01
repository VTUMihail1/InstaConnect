namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Responses;

public record AccessToken(
    string Value,
    DateTimeOffset ExpiresAtUtc);
