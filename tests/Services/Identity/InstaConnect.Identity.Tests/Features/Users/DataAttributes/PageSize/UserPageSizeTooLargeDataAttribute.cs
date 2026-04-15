namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserPageSizeTooLargeDataAttribute : TooLargeIntDataAttribute
{
    public UserPageSizeTooLargeDataAttribute()
        : base(UserConfigurations.PageSizeMaxValue)
    {
    }
}

