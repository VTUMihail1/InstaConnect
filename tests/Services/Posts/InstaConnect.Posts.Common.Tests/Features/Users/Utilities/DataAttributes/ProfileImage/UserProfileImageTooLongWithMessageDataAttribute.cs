using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Length;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.ProfileImage;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserProfileImageTooLongWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public UserProfileImageTooLongWithMessageDataAttribute()
        : base(UserOutOfBoundsUtilities.ProfileImageTooLong, UserErrorMessages.GetProfileImageTooLong(UserOutOfBoundsUtilities.ProfileImageTooLong))
    {
    }
}
