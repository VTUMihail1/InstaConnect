using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Length;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Name;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserNameTooShortWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public UserNameTooShortWithMessageDataAttribute()
        : base(UserOutOfBoundsUtilities.NameTooShort, UserErrorMessages.GetNameTooShort(UserOutOfBoundsUtilities.NameTooShort))
    {
    }
}
