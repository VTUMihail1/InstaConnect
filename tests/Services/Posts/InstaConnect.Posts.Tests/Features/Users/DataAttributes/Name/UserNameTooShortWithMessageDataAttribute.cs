using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.Users.DataAttributes.Name;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserNameTooShortWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public UserNameTooShortWithMessageDataAttribute()
        : base(UserOutOfBoundsUtilities.NameTooShort, UserErrorMessages.GetNameTooShort(UserOutOfBoundsUtilities.NameTooShort))
    {
    }
}
