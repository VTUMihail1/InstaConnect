namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.Page;


[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserPageTooLargeWithMessageDataAttribute : TooLargeIntWithMessageDataAttribute
{
	public UserPageTooLargeWithMessageDataAttribute()
		: base(UserConfigurations.PageMaxValue)
	{
	}
}

