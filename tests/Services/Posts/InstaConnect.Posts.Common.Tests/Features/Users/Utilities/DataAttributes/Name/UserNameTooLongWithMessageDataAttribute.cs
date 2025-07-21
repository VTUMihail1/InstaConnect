using InstaConnect.Common.Tests.Utilities.Types.Strings.Length;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Name;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserNameTooLongWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public UserNameTooLongWithMessageDataAttribute()
        : base(UserOutOfBoundUtilities.NameTooLong, UserErrorMessages.GetNameTooLong(UserOutOfBoundUtilities.NameTooLong))
    {
    }
}
