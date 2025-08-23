using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Length;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserIdTooShortWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public UserIdTooShortWithMessageDataAttribute()
        : base(UserOutOfBoundsUtilities.IdTooShort, UserErrorMessages.GetIdTooShort(UserOutOfBoundsUtilities.IdTooShort))
    {
    }
}
