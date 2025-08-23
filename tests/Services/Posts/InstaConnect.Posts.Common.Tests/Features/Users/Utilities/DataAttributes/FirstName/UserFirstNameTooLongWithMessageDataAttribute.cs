using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Length;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.FirstName;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserFirstNameTooLongWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public UserFirstNameTooLongWithMessageDataAttribute()
        : base(UserOutOfBoundsUtilities.FirstNameTooLong, UserErrorMessages.GetFirstNameTooLong(UserOutOfBoundsUtilities.FirstNameTooLong))
    {
    }
}
