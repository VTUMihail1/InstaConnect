namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;

public class RefreshToken : IEntity
{
    private RefreshToken()
    {
        Id = string.Empty;
        Value = string.Empty;
    }

    public RefreshToken(
        string id,
        string value,
        DateTimeOffset expiresAt,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        Value = value;
        ExpiresAt = expiresAt;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public string Id { get; }

    public string Value { get; }

    public DateTimeOffset ExpiresAt { get; }

    public DateTimeOffset CreatedAt { get; }

    public DateTimeOffset UpdatedAt { get; }

    public bool HasExpired(DateTimeOffset utcNow)
    {
        var hasExpired = ExpiresAt < utcNow;

        return hasExpired;
    }
}


