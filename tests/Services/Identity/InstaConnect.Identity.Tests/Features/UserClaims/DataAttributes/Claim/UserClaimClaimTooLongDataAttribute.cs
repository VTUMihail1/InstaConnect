namespace InstaConnect.Identity.Tests.Features.UserClaims.DataAttributes.Claim;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserClaimClaimTooLongDataAttribute : TooLongStringDataAttribute
{
    public UserClaimClaimTooLongDataAttribute()
        : base(UserClaimConfigurations.ClaimMaxLength)
    {
    }
}
