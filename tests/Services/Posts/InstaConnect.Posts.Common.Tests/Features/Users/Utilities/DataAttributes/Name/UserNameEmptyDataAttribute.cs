using InstaConnect.Common.Tests.Utilities.DataAttributes;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Name;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserNameEmptyDataAttribute : EmptyStringDataAttribute
{
    public UserNameEmptyDataAttribute()
        : base(UserErrorMessages.GetNameEmpty())
    {
    }
}

