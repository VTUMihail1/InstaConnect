using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Length;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Name;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserNameTooShortWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public UserNameTooShortWithMessageDataAttribute()
        : base(UserOutOfBoundUtilities.NameTooShort, UserErrorMessages.GetNameTooShort(UserOutOfBoundUtilities.NameTooShort))
    {
    }
}
