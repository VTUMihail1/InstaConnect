namespace InstaConnect.Identity.Tests.Features.UserClaims.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserClaimPageSizeTooSmallWithMessageDataAttribute : TooSmallIntWithMessageDataAttribute
{
    public UserClaimPageSizeTooSmallWithMessageDataAttribute()
        : base(UserClaimConfigurations.PageSizeMinValue)
    {
    }
}
