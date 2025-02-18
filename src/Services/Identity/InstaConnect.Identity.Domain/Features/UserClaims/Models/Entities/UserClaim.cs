using InstaConnect.Identity.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Models.Entities;

public class UserClaim : BaseEntity
{
    public UserClaim(string claim, string value, string userId)
    {
        Claim = claim;
        Value = value;
        UserId = userId;
    }

    public UserClaim(string claim, string value, User user)
    {
        Claim = claim;
        Value = value;
        UserId = user.Id;
        User = user;
    }

    public string Claim { get; }

    public string Value { get; }

    public string UserId { get; }

    public User? User { get; set; }
}
