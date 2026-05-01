namespace InstaConnect.Posts.Tests.Features.Users.DataAttributes.Name;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserNameTooShortWithMessageDataAttribute : TooShortStringWithMessageDataAttribute
{
	public UserNameTooShortWithMessageDataAttribute()
		: base(UserConfigurations.NameMinLength)
	{
	}
}
