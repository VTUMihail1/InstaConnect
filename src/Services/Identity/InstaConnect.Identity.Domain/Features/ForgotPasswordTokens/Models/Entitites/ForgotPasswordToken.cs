using InstaConnect.Identity.Domain.Features.Users.Models.Entitites;
using InstaConnect.Shared.Domain.Models.Base;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entitites;

public class ForgotPasswordToken : BaseEntity
{
    public ForgotPasswordToken(string value, DateTime validUntil, string userId)
    {
        Value = value;
        ValidUntil = validUntil;
        UserId = userId;
    }

    public string Value { get; }

    public DateTime ValidUntil { get; }

    public string UserId { get; }

    public User? User { get; set; }
}
