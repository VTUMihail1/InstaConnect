namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Responses;

public record AccessToken(string Id, string Value, DateTimeOffset ExpiresAt);
