using InstaConnect.Common.Tests.Utilities.Types.Strings.Empty;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserIdEmptyWithMessageDataAttribute : EmptyStringWithMessageDataAttribute
{
    public UserIdEmptyWithMessageDataAttribute()
        : base(UserErrorMessages.GetIdEmpty())
    {
    }
}
