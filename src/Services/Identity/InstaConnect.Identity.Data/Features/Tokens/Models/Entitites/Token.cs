using InstaConnect.Identity.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Identity.Data.Features.Tokens.Models.Entitites;

public class Token : BaseEntity
{
    public Token(string value, string type, DateTime validUntil, string userId)
    {
        Value = value;
        Type = type;
        ValidUntil = validUntil;
        UserId = userId;
    }

    public string Value { get; }

    public string Type { get; }

    public DateTime ValidUntil { get; }

    public string UserId { get; }

    public User? User { get; set; }
}
