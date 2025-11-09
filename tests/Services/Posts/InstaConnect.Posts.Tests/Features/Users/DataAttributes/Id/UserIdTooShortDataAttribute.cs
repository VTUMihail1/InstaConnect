using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.Users.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserIdTooShortDataAttribute : LengthStringDataAttribute
{
    public UserIdTooShortDataAttribute()
        : base(UserOutOfBoundsUtilities.IdTooShort)
    {
    }
}
