using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.Users.DataAttributes.Name;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserNameTooShortDataAttribute : LengthStringDataAttribute
{
    public UserNameTooShortDataAttribute()
        : base(UserOutOfBoundsUtilities.NameTooShort)
    {
    }
}
