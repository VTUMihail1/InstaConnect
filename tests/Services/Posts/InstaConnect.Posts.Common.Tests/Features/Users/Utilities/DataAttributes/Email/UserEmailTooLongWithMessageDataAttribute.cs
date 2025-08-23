using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Length;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Email;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserEmailTooLongWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public UserEmailTooLongWithMessageDataAttribute()
        : base(UserOutOfBoundsUtilities.EmailTooLong, UserErrorMessages.GetEmailTooLong(UserOutOfBoundsUtilities.EmailTooLong))
    {
    }
}
