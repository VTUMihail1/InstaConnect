namespace InstaConnect.Follows.Tests.Features.Users.DataAttributes.ProfileImage;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserProfileImageTooLongWithMessageDataAttribute : TooLongStringWithMessageDataAttribute
{
	public UserProfileImageTooLongWithMessageDataAttribute()
		: base(UserConfigurations.ProfileImageUrlMaxLength)
	{
	}
}
