using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.Users.DataAttributes.LastName;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserLastNameTooShortWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public UserLastNameTooShortWithMessageDataAttribute()
        : base(UserOutOfBoundsUtilities.LastNameTooShort, UserErrorMessages.GetLastNameTooShort(UserOutOfBoundsUtilities.LastNameTooShort))
    {
    }
}
