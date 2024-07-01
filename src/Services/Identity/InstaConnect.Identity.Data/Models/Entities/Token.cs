using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Identity.Data.Models.Entities;

public class Token : BaseEntity
{
    public string Value { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

    public DateTime ValidUntil { get; set; } = DateTime.Now;

    public string UserId { get; set; } = string.Empty;

    public User User { get; set; } = new();
}
