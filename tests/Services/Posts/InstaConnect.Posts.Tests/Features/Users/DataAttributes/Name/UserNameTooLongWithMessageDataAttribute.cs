using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.Users.DataAttributes.Name;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserNameTooLongWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public UserNameTooLongWithMessageDataAttribute()
        : base(UserOutOfBoundsUtilities.NameTooLong, UserErrorMessages.GetNameTooLong(UserOutOfBoundsUtilities.NameTooLong))
    {
    }
}
