namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserPageTooSmallWithMessageDataAttribute : TooSmallIntWithMessageDataAttribute
{
    public UserPageTooSmallWithMessageDataAttribute()
        : base(UserConfigurations.PageMinValue)
    {
    }
}

