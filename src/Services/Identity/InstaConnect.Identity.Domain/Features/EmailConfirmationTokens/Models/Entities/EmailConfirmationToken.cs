namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entities;

public class EmailConfirmationToken : IEntity<EmailConfirmationTokenId>
{
    private EmailConfirmationToken()
    {
        Id = new(new(string.Empty), string.Empty);
    }

    public EmailConfirmationToken(
        EmailConfirmationTokenId id,
        DateTimeOffset expiresAtUtc,
        DateTimeOffset createdAtUtc)
    {
        Id = id;
        ExpiresAtUtc = expiresAtUtc;
        CreatedAtUtc = createdAtUtc;
    }

    public EmailConfirmationTokenId Id { get; }

    public DateTimeOffset ExpiresAtUtc { get; }

    public DateTimeOffset CreatedAtUtc { get; }

    public bool HasExpired(DateTimeOffset utcNow)
    {
        var hasExpired = ExpiresAtUtc < utcNow;

        return hasExpired;
    }
}


