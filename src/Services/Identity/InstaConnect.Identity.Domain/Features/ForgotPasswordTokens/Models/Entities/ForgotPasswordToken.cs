namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entities;

public class ForgotPasswordToken : IEntity
{
    private ForgotPasswordToken()
    {
        Id = string.Empty;
        Value = string.Empty;
    }

    public ForgotPasswordToken(
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


