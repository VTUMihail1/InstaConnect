namespace InstaConnect.Identity.Tests.Features.UserClaims.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserClaimPageSizeTooLargeWithMessageDataAttribute : TooLargeIntWithMessageDataAttribute
{
    public UserClaimPageSizeTooLargeWithMessageDataAttribute()
        : base(UserClaimConfigurations.PageSizeMaxValue)
    {
    }
}
