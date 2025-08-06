using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Null;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.FirstName;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserFirstNameNullWithMessageDataAttribute : NullStringWithMessageDataAttribute
{
    public UserFirstNameNullWithMessageDataAttribute()
        : base(UserErrorMessages.GetFirstNameEmpty())
    {
    }
}
