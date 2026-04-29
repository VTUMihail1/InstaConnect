namespace InstaConnect.Identity.Tests.Features.UserClaims.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserClaimPageTooLargeDataAttribute : TooLargeIntDataAttribute
{
	public UserClaimPageTooLargeDataAttribute()
		: base(UserClaimConfigurations.PageMaxValue)
	{
	}
}

