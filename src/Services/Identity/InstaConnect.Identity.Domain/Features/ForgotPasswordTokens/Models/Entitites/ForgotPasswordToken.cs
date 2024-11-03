using InstaConnect.Identity.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Models.Entitites;

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
