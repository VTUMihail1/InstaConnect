namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.Email;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserEmailTooShortWithMessageDataAttribute : TooShortStringWithMessageDataAttribute
{
    public UserEmailTooShortWithMessageDataAttribute()
        : base(UserConfigurations.EmailMinLength)
    {
    }
}
