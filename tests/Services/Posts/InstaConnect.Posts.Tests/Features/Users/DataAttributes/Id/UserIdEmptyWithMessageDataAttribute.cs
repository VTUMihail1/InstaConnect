namespace InstaConnect.Posts.Tests.Features.Users.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserIdEmptyWithMessageDataAttribute : EmptyStringWithMessageDataAttribute
{
    public UserIdEmptyWithMessageDataAttribute()
        : base(UserErrorMessages.GetIdEmpty())
    {
    }
}
