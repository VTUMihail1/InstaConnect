using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.Users.DataAttributes.FirstName;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserFirstNameTooLongWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public UserFirstNameTooLongWithMessageDataAttribute()
        : base(UserOutOfBoundsUtilities.FirstNameTooLong, UserErrorMessages.GetFirstNameTooLong(UserOutOfBoundsUtilities.FirstNameTooLong))
    {
    }
}
