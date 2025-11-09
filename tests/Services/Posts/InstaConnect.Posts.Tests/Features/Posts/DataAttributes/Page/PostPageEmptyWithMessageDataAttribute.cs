namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostPageEmptyWithMessageDataAttribute : EmptyIntWithMessageDataAttribute
{
    public PostPageEmptyWithMessageDataAttribute()
        : base(PostErrorMessages.GetPageEmpty())
    {
    }
}
