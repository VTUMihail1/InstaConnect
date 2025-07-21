using InstaConnect.Common.Tests.Utilities.Types.Strings.Length;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserIdTooShortWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public UserIdTooShortWithMessageDataAttribute()
        : base(UserOutOfBoundUtilities.IdTooShort, UserErrorMessages.GetIdTooShort(UserOutOfBoundUtilities.IdTooShort))
    {
    }
}
