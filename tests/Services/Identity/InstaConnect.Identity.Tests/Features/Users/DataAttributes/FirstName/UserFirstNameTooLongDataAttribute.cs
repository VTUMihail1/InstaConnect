namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.FirstName;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserFirstNameTooLongDataAttribute : TooLongStringDataAttribute
{
    public UserFirstNameTooLongDataAttribute()
        : base(UserConfigurations.FirstNameMaxLength)
    {
    }
}
