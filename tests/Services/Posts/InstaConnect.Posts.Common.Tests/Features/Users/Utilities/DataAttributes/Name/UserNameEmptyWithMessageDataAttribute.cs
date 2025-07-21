using InstaConnect.Common.Tests.Utilities.Types.Strings.Empty;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Name;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserNameEmptyWithMessageDataAttribute : EmptyStringWithMessageDataAttribute
{
    public UserNameEmptyWithMessageDataAttribute()
        : base(UserErrorMessages.GetNameEmpty())
    {
    }
}
