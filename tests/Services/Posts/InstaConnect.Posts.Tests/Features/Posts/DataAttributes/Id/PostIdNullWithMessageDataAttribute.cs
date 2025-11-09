namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostIdNullWithMessageDataAttribute : NullStringWithMessageDataAttribute
{
    public PostIdNullWithMessageDataAttribute()
        : base(PostErrorMessages.GetIdEmpty())
    {
    }
}

