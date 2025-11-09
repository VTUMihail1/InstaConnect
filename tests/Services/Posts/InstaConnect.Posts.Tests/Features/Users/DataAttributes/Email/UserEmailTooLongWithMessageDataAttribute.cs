using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.Users.DataAttributes.Email;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserEmailTooLongWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public UserEmailTooLongWithMessageDataAttribute()
        : base(UserOutOfBoundsUtilities.EmailTooLong, UserErrorMessages.GetEmailTooLong(UserOutOfBoundsUtilities.EmailTooLong))
    {
    }
}
