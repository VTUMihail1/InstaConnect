namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserPageTooLargeDataAttribute : TooLargeIntDataAttribute
{
	public UserPageTooLargeDataAttribute()
		: base(UserConfigurations.PageMaxValue)
	{
	}
}

