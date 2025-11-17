namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;

public class RefreshToken : IEntity<RefreshTokenId>
{
    private RefreshToken()
    {
        Id = new(new(string.Empty), string.Empty);
    }

    public RefreshToken(
        RefreshTokenId id,
        DateTimeOffset expiresAtUtc,
        DateTimeOffset createdAtUtc)
    {
        Id = id;
        ExpiresAtUtc = expiresAtUtc;
        CreatedAtUtc = createdAtUtc;
    }

    public RefreshTokenId Id { get; }

    public DateTimeOffset ExpiresAtUtc { get; }

    public DateTimeOffset CreatedAtUtc { get; }

    public bool HasExpired(DateTimeOffset utcNow)
    {
        var hasExpired = ExpiresAtUtc < utcNow;

        return hasExpired;
    }
}


