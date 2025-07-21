using InstaConnect.Common.Tests.Utilities.Types.Strings.Null;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Name;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserNameNullWithMessageDataAttribute : NullStringWithMessageDataAttribute
{
    public UserNameNullWithMessageDataAttribute()
        : base(UserErrorMessages.GetNameEmpty())
    {
    }
}
