namespace InstaConnect.Posts.Tests.Features.Users.DataAttributes.ProfileImage;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserProfileImageEmptyDataAttribute : EmptyStringDataAttribute
{
}
