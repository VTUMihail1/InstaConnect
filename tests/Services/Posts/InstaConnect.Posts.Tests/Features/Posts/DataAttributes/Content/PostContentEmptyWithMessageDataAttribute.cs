namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Content;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostContentEmptyWithMessageDataAttribute : EmptyStringWithMessageDataAttribute
{
    public PostContentEmptyWithMessageDataAttribute()
        : base(PostErrorMessages.GetContentEmpty())
    {
    }
}
