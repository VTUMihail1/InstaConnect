namespace InstaConnect.Identity.Domain.Features.UserClaims.Models.Entities;

public class UserClaim : IEntity<UserClaimId>
{
    public UserClaim()
    {
        Id = new(new(string.Empty), string.Empty);
    }

    public UserClaim(UserClaimId id, DateTimeOffset createdAtUtc)
    {
        Id = id;
        CreatedAtUtc = createdAtUtc;
    }

    public UserClaimId Id { get; }

    public DateTimeOffset CreatedAtUtc { get; }
}
