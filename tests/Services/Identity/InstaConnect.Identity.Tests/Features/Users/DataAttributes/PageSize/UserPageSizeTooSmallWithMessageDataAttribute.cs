namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserPageSizeTooSmallWithMessageDataAttribute : TooSmallIntWithMessageDataAttribute
{
	public UserPageSizeTooSmallWithMessageDataAttribute()
		: base(UserConfigurations.PageSizeMinValue)
	{
	}
}
