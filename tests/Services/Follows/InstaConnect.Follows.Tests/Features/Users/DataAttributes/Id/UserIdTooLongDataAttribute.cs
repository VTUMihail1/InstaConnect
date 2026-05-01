namespace InstaConnect.Follows.Tests.Features.Users.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserIdTooLongDataAttribute : TooLongStringDataAttribute
{
	public UserIdTooLongDataAttribute()
		: base(UserConfigurations.IdMaxLength)
	{
	}
}
