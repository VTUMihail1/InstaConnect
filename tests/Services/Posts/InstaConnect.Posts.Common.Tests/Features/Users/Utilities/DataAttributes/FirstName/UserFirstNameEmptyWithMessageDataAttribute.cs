using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Empty;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.FirstName;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserFirstNameEmptyWithMessageDataAttribute : EmptyStringWithMessageDataAttribute
{
    public UserFirstNameEmptyWithMessageDataAttribute()
        : base(UserErrorMessages.GetFirstNameEmpty())
    {
    }
}
