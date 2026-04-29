namespace InstaConnect.Identity.Tests.Features.UserClaims.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserClaimPageTooSmallWithMessageDataAttribute : TooSmallIntWithMessageDataAttribute
{
	public UserClaimPageTooSmallWithMessageDataAttribute()
		: base(UserClaimConfigurations.PageMinValue)
	{
	}
}

