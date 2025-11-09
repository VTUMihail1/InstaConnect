using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.Users.DataAttributes.ProfileImage;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserProfileImageTooLongDataAttribute : LengthStringDataAttribute
{
    public UserProfileImageTooLongDataAttribute()
        : base(UserOutOfBoundsUtilities.ProfileImageTooLong)
    {
    }
}
