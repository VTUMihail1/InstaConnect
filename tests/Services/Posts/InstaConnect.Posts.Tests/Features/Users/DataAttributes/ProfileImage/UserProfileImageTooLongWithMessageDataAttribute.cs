using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.Users.DataAttributes.ProfileImage;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserProfileImageTooLongWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public UserProfileImageTooLongWithMessageDataAttribute()
        : base(UserOutOfBoundsUtilities.ProfileImageTooLong, UserErrorMessages.GetProfileImageTooLong(UserOutOfBoundsUtilities.ProfileImageTooLong))
    {
    }
}
