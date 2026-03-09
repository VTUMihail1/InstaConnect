namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.Name;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserNameTooLongWithMessageDataAttribute : TooLongStringWithMessageDataAttribute
{
    public UserNameTooLongWithMessageDataAttribute()
        : base(UserConfigurations.NameMaxLength)
    {
    }
}
