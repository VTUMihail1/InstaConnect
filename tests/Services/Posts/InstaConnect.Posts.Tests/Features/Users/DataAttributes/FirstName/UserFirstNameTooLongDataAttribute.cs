using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.Users.DataAttributes.FirstName;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserFirstNameTooLongDataAttribute : LengthStringDataAttribute
{
    public UserFirstNameTooLongDataAttribute()
        : base(UserOutOfBoundsUtilities.FirstNameTooLong)
    {
    }
}
