namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserPageTooSmallDataAttribute : TooSmallValueIntDataAttribute
{
	public UserPageTooSmallDataAttribute()
		: base(UserConfigurations.PageMinValue)
	{
	}
}

