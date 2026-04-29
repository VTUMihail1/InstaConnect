namespace InstaConnect.Identity.Tests.Features.UserClaims.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserClaimPageSizeTooSmallDataAttribute : TooSmallValueIntDataAttribute
{
	public UserClaimPageSizeTooSmallDataAttribute()
		: base(UserClaimConfigurations.PageSizeMinValue)
	{
	}
}

