namespace InstaConnect.Posts.Tests.Features.Users.DataAttributes.Name;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserNameEmptyWithMessageDataAttribute : EmptyStringWithMessageDataAttribute
{
    public UserNameEmptyWithMessageDataAttribute()
        : base(UserErrorMessages.GetNameEmpty())
    {
    }
}
