using InstaConnect.Common.Domain.Features.Entities.Abstractions;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;

public class RefreshToken : IEntityWithId<RefreshTokenId>
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

    public User? User { get; private set; }

    public RefreshToken AddUser(User? user)
    {
        User = user;

        return this;
    }

    public bool HasExpired(DateTimeOffset utcNow)
    {
        var hasExpired = ExpiresAtUtc < utcNow;

        return hasExpired;
    }
}


