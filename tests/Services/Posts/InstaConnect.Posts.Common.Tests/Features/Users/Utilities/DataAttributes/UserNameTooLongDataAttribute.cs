using InstaConnect.Common.Tests.Utilities.DataAttributes;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserNameTooLongDataAttribute : OutOfBoundsStringDataAttribute
{
    public UserNameTooLongDataAttribute()
        : base(UserOutOfBoundUtilities.NameTooLong, UserErrorMessages.GetNameTooLong(UserOutOfBoundUtilities.NameTooLong))
    {
    }
}
