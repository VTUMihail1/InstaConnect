using InstaConnect.Common.Tests.Utilities.DataAttributes;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserIdEmptyDataAttribute : EmptyStringDataAttribute
{
    public UserIdEmptyDataAttribute()
        : base(UserErrorMessages.GetIdEmpty())
    {
    }
}

