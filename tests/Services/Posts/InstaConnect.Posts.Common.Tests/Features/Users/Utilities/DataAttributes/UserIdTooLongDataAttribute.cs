using InstaConnect.Common.Tests.Utilities.DataAttributes;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserIdTooLongDataAttribute : OutOfBoundsStringDataAttribute
{
    public UserIdTooLongDataAttribute()
        : base(UserOutOfBoundUtilities.IdTooLong, UserErrorMessages.GetIdTooLong(UserOutOfBoundUtilities.IdTooLong))
    {
    }
}
