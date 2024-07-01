using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Identity.Data.Models.Entities;

public class UserClaim : BaseEntity
{
    public string Claim { get; set; } = string.Empty;

    public string Value { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;

    public User User { get; set; } = new();
}
