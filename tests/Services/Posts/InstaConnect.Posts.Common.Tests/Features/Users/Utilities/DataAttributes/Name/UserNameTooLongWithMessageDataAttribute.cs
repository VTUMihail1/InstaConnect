using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Length;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Name;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserNameTooLongWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public UserNameTooLongWithMessageDataAttribute()
        : base(UserTestValueUtilities.NameTooLong, UserErrorMessages.GetNameTooLong(UserTestValueUtilities.NameTooLong))
    {
    }
}
