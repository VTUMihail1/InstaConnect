namespace InstaConnect.RefreshTokens.Infrastructure.Features.RefreshTokens.Models;

public record RefreshTokenQueryEntity(
        string Id,
        string Value,
        DateTimeOffset ExpiresAt,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt);
