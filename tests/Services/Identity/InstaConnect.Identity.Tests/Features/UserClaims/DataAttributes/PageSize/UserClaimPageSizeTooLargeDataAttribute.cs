namespace InstaConnect.Identity.Tests.Features.UserClaims.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserClaimPageSizeTooLargeDataAttribute : TooLargeIntDataAttribute
{
    public UserClaimPageSizeTooLargeDataAttribute()
        : base(UserClaimConfigurations.PageSizeMaxValue)
    {
    }
}

