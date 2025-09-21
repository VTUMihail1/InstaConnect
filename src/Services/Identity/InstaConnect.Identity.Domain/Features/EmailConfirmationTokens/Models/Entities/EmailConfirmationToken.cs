namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entities;

public class EmailConfirmationToken : IEntity
{
    private EmailConfirmationToken()
    {
        Id = string.Empty;
        Value = string.Empty;
    }

    public EmailConfirmationToken(
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


