namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserIdTooShortWithMessageDataAttribute : TooShortStringWithMessageDataAttribute
{
	public UserIdTooShortWithMessageDataAttribute()
		: base(UserConfigurations.IdMinLength)
	{
	}
}
