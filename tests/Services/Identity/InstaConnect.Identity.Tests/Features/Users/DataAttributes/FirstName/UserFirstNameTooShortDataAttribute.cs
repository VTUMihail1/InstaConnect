namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.FirstName;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserFirstNameTooShortDataAttribute : TooShortStringDataAttribute
{
    public UserFirstNameTooShortDataAttribute()
        : base(UserConfigurations.FirstNameMinLength)
    {
    }
}
