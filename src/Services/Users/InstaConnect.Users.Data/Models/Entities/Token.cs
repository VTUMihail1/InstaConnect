using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Users.Data.Models.Entities;

public class Token : BaseEntity
{
    public string Value { get; set; }

    public string Type { get; set; }

    public DateTime ValidUntil { get; set; }

    public string UserId { get; set; }

    public User User { get; set; }
}
