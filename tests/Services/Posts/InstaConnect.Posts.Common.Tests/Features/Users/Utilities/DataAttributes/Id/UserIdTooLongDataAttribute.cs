using InstaConnect.Common.Tests.Utilities.DataAttributes.String;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserIdTooLongDataAttribute : OutOfBoundsStringWithMessageDataAttribute
{
    public UserIdTooLongDataAttribute()
        : base(UserOutOfBoundUtilities.IdTooLong, UserErrorMessages.GetIdTooLong(UserOutOfBoundUtilities.IdTooLong))
    {
    }
}
