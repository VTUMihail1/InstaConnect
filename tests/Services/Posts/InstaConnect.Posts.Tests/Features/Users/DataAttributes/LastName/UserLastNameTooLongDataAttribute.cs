using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.Users.DataAttributes.LastName;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserLastNameTooLongDataAttribute : LengthStringDataAttribute
{
    public UserLastNameTooLongDataAttribute()
        : base(UserOutOfBoundsUtilities.LastNameTooLong)
    {
    }
}
