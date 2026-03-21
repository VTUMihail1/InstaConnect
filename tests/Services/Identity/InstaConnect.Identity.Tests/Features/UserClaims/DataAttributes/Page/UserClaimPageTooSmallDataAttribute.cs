namespace InstaConnect.Identity.Tests.Features.UserClaims.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserClaimPageTooSmallDataAttribute : TooSmallValueIntDataAttribute
{
    public UserClaimPageTooSmallDataAttribute()
        : base(UserClaimConfigurations.PageMinValue)
    {
    }
}

