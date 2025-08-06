using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Length;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.LastName;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserLastNameTooLongWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public UserLastNameTooLongWithMessageDataAttribute()
        : base(UserTestValueUtilities.LastNameTooLong, UserErrorMessages.GetLastNameTooLong(UserTestValueUtilities.LastNameTooLong))
    {
    }
}
