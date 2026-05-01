namespace InstaConnect.Posts.Tests.Features.Users.DataAttributes.LastName;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserLastNameTooLongDataAttribute : TooLongStringDataAttribute
{
	public UserLastNameTooLongDataAttribute()
		: base(UserConfigurations.LastNameMaxLength)
	{
	}
}
