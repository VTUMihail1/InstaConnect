namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entities;

public class ForgotPasswordToken : IEntityWithId<ForgotPasswordTokenId>
{
    private ForgotPasswordToken()
    {
        Id = new(new(string.Empty), string.Empty);
    }

    public ForgotPasswordToken(
        ForgotPasswordTokenId id,
        DateTimeOffset expiresAtUtc,
        DateTimeOffset createdAtUtc)
    {
        Id = id;
        ExpiresAtUtc = expiresAtUtc;
        CreatedAtUtc = createdAtUtc;
    }

    public ForgotPasswordTokenId Id { get; }

    public DateTimeOffset ExpiresAtUtc { get; }

    public DateTimeOffset CreatedAtUtc { get; }

    public bool HasExpired(DateTimeOffset utcNow)
    {
        var hasExpired = ExpiresAtUtc < utcNow;

        return hasExpired;
    }
}


