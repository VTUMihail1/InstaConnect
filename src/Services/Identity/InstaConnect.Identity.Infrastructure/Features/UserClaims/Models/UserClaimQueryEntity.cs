namespace InstaConnect.UserClaims.Infrastructure.Features.UserClaims.Models;

public record UserClaimQueryEntity(
        string Id,
        string Claim,
        string Value,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt);
