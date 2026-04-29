namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.Name;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserNameTooShortDataAttribute : TooShortStringDataAttribute
{
	public UserNameTooShortDataAttribute()
		: base(UserConfigurations.NameMinLength)
	{
	}
}
