namespace InstaConnect.EmailConfirmationTokens.Infrastructure.Features.EmailConfirmationTokens.Models;

public record EmailConfirmationTokenQueryEntity(
        string Id,
        string Value,
        DateTimeOffset ExpiresAt,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt);
