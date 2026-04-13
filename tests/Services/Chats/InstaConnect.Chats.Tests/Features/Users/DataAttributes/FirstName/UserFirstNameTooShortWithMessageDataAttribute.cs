namespace InstaConnect.Chats.Tests.Features.Users.DataAttributes.FirstName;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserFirstNameTooShortWithMessageDataAttribute : TooShortStringWithMessageDataAttribute
{
    public UserFirstNameTooShortWithMessageDataAttribute()
        : base(UserConfigurations.FirstNameMinLength)
    {
    }
}
