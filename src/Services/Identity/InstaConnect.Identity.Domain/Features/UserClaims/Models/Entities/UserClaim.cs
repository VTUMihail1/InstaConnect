namespace InstaConnect.Identity.Domain.Features.UserClaims.Models.Entities;

public class UserClaim : IEntity
{
    public UserClaim()
    {
        Id = string.Empty;
        Claim = string.Empty;
        Value = string.Empty;
    }

    public UserClaim(string id, string claim, string value, DateTimeOffset createdAt, DateTimeOffset updatedAt)
    {
        Id = id;
        Claim = claim;
        Value = value;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public string Id { get; }

    public string Claim { get; }

    public string Value { get; }

    public DateTimeOffset CreatedAt { get; }

    public DateTimeOffset UpdatedAt { get; }
}
