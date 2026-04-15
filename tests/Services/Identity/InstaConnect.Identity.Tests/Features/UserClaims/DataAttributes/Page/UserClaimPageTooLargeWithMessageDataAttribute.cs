namespace InstaConnect.Identity.Tests.Features.UserClaims.DataAttributes.Page;


[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserClaimPageTooLargeWithMessageDataAttribute : TooLargeIntWithMessageDataAttribute
{
    public UserClaimPageTooLargeWithMessageDataAttribute()
        : base(UserClaimConfigurations.PageMaxValue)
    {
    }
}

