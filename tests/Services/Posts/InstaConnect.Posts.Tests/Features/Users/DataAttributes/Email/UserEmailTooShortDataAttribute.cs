using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.Users.DataAttributes.Email;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserEmailTooShortDataAttribute : LengthStringDataAttribute
{
    public UserEmailTooShortDataAttribute()
        : base(UserOutOfBoundsUtilities.EmailTooShort)
    {
    }
}
