using InstaConnect.Identity.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entities;

public class ForgotPasswordToken : BaseEntity
{
    public ForgotPasswordToken(string value, DateTimeOffset validUntil, string userId)
    {
        Value = value;
        ValidUntil = validUntil;
        UserId = userId;
    }

    public ForgotPasswordToken(string value, DateTimeOffset validUntil, User user)
    {
        Value = value;
        ValidUntil = validUntil;
        UserId = user.Id;
        User = user;
    }

    public string Value { get; }

    public DateTimeOffset ValidUntil { get; }

    public string UserId { get; }

    public User? User { get; set; }
}
