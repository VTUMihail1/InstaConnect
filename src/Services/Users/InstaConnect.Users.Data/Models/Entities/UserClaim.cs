using InstaConnect.Shared.Data.Models.Base;
using InstaConnect.Users.Data.Models.Enums;

namespace InstaConnect.Users.Data.Models.Entities;

public class UserClaim : BaseEntity
{

    public Claims Claim { get; set; }

    public string Value { get; set; }

    public string UserId { get; set; }

    public User User { get; set; }
}
