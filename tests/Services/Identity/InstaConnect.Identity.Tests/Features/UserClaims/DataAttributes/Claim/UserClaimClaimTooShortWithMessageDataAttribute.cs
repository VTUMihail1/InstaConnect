namespace InstaConnect.Identity.Tests.Features.UserClaims.DataAttributes.Claim;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserClaimClaimTooShortWithMessageDataAttribute : TooShortStringWithMessageDataAttribute
{
    public UserClaimClaimTooShortWithMessageDataAttribute()
        : base(UserClaimConfigurations.ClaimMinLength)
    {
    }
}
