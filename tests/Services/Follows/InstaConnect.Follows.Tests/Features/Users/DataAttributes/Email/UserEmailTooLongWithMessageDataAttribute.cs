namespace InstaConnect.Follows.Tests.Features.Users.DataAttributes.Email;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserEmailTooLongWithMessageDataAttribute : TooLongStringWithMessageDataAttribute
{
    public UserEmailTooLongWithMessageDataAttribute()
        : base(UserConfigurations.EmailMaxLength)
    {
    }
}
