using InstaConnect.Common.Tests.Utilities.DataAttributes.String;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Name;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserNameTooShortDataAttribute : OutOfBoundsStringWithMessageDataAttribute
{
    public UserNameTooShortDataAttribute()
        : base(UserOutOfBoundUtilities.NameTooShort, UserErrorMessages.GetNameTooShort(UserOutOfBoundUtilities.NameTooShort))
    {
    }
}
