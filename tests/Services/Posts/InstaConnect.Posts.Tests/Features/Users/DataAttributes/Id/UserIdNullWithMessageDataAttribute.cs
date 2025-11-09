namespace InstaConnect.Posts.Tests.Features.Users.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserIdNullWithMessageDataAttribute : NullStringWithMessageDataAttribute
{
    public UserIdNullWithMessageDataAttribute()
        : base(UserErrorMessages.GetIdEmpty())
    {
    }
}
