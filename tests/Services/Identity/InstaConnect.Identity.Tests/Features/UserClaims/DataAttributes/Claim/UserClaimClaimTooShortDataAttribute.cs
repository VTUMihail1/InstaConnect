namespace InstaConnect.Identity.Tests.Features.UserClaims.DataAttributes.Claim;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserClaimClaimTooShortDataAttribute : TooShortStringDataAttribute
{
    public UserClaimClaimTooShortDataAttribute()
        : base(UserClaimConfigurations.ClaimMinLength)
    {
    }
}
