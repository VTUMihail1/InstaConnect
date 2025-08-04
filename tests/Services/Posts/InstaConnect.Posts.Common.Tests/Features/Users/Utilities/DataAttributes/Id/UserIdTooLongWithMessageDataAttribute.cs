using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Length;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserIdTooLongWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public UserIdTooLongWithMessageDataAttribute()
        : base(UserOutOfBoundUtilities.IdTooLong, UserErrorMessages.GetIdTooLong(UserOutOfBoundUtilities.IdTooLong))
    {
    }
}
