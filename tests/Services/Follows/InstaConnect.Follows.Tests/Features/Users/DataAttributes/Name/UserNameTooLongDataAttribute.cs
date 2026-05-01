namespace InstaConnect.Follows.Tests.Features.Users.DataAttributes.Name;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserNameTooLongDataAttribute : TooLongStringDataAttribute
{
	public UserNameTooLongDataAttribute()
		: base(UserConfigurations.NameMaxLength)
	{
	}
}
