using InstaConnect.Identity.Domain.Features.Users.Models.Entitites;
using InstaConnect.Shared.Domain.Models.Base;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entitites;

public class EmailConfirmationToken : BaseEntity
{
    public EmailConfirmationToken(string value, DateTime validUntil, string userId)
    {
        Value = value;
        ValidUntil = validUntil;
        UserId = userId;
    }

    public EmailConfirmationToken(string value, DateTime validUntil, User user)
    {
        Value = value;
        ValidUntil = validUntil;
        UserId = user.Id;
        User = user;
    }

    public string Value { get; }

    public DateTime ValidUntil { get; }

    public string UserId { get; }

    public User? User { get; set; }
}
