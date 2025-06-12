using InstaConnect.Common.Tests.Utilities.DataAttributes;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserIdOutOfBoundsMinDataAttribute : OutOfBoundsMinStringDataAttribute
{
    public UserIdOutOfBoundsMinDataAttribute()
        : base(UserConfigurations.IdMinLength)
    {
    }
}
