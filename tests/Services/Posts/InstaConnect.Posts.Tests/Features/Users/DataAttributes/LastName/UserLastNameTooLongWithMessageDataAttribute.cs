using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.Users.DataAttributes.LastName;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserLastNameTooLongWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public UserLastNameTooLongWithMessageDataAttribute()
        : base(UserOutOfBoundsUtilities.LastNameTooLong, UserErrorMessages.GetLastNameTooLong(UserOutOfBoundsUtilities.LastNameTooLong))
    {
    }
}
