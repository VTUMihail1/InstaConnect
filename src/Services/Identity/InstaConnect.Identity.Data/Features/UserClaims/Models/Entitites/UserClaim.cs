using InstaConnect.Identity.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Identity.Data.Features.UserClaims.Models.Entitites;

public class UserClaim : BaseEntity
{
    public UserClaim(string claim, string value, string userId)
    {
        Claim = claim;
        Value = value;
        UserId = userId;
    }

    public string Claim { get; }

    public string Value { get; }

    public string UserId { get; }

    public User? User { get; set; }
}
