using InstaConnect.Common.Tests.Utilities.DataAttributes;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Null;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserIdNullWithMessageDataAttribute : NullStringWithMessageDataAttribute
{
    public UserIdNullWithMessageDataAttribute()
        : base(UserErrorMessages.GetIdEmpty())
    {
    }
}
