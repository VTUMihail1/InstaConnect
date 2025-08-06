using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Length;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Email;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserEmailTooShortWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public UserEmailTooShortWithMessageDataAttribute()
        : base(UserTestValueUtilities.EmailTooShort, UserErrorMessages.GetEmailTooShort(UserTestValueUtilities.EmailTooShort))
    {
    }
}
