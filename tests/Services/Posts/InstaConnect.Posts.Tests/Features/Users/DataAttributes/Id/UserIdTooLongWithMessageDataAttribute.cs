using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.Users.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserIdTooLongWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public UserIdTooLongWithMessageDataAttribute()
        : base(UserOutOfBoundsUtilities.IdTooLong, UserErrorMessages.GetIdTooLong(UserOutOfBoundsUtilities.IdTooLong))
    {
    }
}
