using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Length;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.LastName;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserLastNameTooShortWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public UserLastNameTooShortWithMessageDataAttribute()
        : base(UserTestValueUtilities.LastNameTooShort, UserErrorMessages.GetLastNameTooShort(UserTestValueUtilities.LastNameTooShort))
    {
    }
}
