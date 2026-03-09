namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.FirstName;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserFirstNameTooLongWithMessageDataAttribute : TooLongStringWithMessageDataAttribute
{
    public UserFirstNameTooLongWithMessageDataAttribute()
        : base(UserConfigurations.FirstNameMaxLength)
    {
    }
}
