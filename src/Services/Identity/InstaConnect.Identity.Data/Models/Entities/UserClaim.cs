using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Identity.Data.Models.Entities;

public class UserClaim : BaseEntity
{
    public string Claim { get; set; }

    public string Value { get; set; }

    public string UserId { get; set; }

    public User User { get; set; }
}
