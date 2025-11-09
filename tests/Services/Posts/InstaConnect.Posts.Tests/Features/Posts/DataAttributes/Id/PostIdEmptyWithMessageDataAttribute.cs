namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostIdEmptyWithMessageDataAttribute : EmptyStringWithMessageDataAttribute
{
    public PostIdEmptyWithMessageDataAttribute()
        : base(PostErrorMessages.GetIdEmpty())
    {
    }
}

