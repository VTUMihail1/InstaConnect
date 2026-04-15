namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserPageSizeTooLargeWithMessageDataAttribute : TooLargeIntWithMessageDataAttribute
{
    public UserPageSizeTooLargeWithMessageDataAttribute()
        : base(UserConfigurations.PageSizeMaxValue)
    {
    }
}
