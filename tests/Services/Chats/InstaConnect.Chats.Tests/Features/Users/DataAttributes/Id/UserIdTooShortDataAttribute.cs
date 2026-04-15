namespace InstaConnect.Chats.Tests.Features.Users.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserIdTooShortDataAttribute : TooShortStringDataAttribute
{
    public UserIdTooShortDataAttribute()
        : base(UserConfigurations.IdMinLength)
    {
    }
}
