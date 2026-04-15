namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserIdTooLongWithMessageDataAttribute : TooLongStringWithMessageDataAttribute
{
    public UserIdTooLongWithMessageDataAttribute()
        : base(UserConfigurations.IdMaxLength)
    {
    }
}
