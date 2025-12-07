namespace InstaConnect.Posts.Tests.Features.Users.DataAttributes.Email;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserEmailTooShortDataAttribute : TooShortStringDataAttribute
{
    public UserEmailTooShortDataAttribute()
        : base(UserConfigurations.EmailMinLength)
    {
    }
}
