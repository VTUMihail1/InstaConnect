using InstaConnect.Common.Tests.Utilities.DataAttributes;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Name;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserNameNullDataAttribute : NullWithMessageDataAttribute
{
    public UserNameNullDataAttribute()
        : base(UserErrorMessages.GetNameEmpty())
    {
    }
}

