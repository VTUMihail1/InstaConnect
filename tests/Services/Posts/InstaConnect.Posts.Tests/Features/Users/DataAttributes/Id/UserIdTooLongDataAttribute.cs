using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.Users.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserIdTooLongDataAttribute : LengthStringDataAttribute
{
    public UserIdTooLongDataAttribute()
        : base(UserOutOfBoundsUtilities.IdTooLong)
    {
    }
}
