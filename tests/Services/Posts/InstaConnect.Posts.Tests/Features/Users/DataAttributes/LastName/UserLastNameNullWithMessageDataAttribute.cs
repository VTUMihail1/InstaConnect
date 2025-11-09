namespace InstaConnect.Posts.Tests.Features.Users.DataAttributes.LastName;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserLastNameNullWithMessageDataAttribute : NullStringWithMessageDataAttribute
{
    public UserLastNameNullWithMessageDataAttribute()
        : base(UserErrorMessages.GetLastNameEmpty())
    {
    }
}
