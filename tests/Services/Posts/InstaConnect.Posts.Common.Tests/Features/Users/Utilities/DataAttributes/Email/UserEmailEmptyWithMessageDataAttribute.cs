using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Empty;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Email;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserEmailEmptyWithMessageDataAttribute : EmptyStringWithMessageDataAttribute
{
    public UserEmailEmptyWithMessageDataAttribute()
        : base(UserErrorMessages.GetEmailEmpty())
    {
    }
}
