namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserPageSizeTooSmallDataAttribute : TooSmallValueIntDataAttribute
{
    public UserPageSizeTooSmallDataAttribute()
        : base(UserConfigurations.PageSizeMinValue)
    {
    }
}

