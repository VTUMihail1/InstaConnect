namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostPageSizeEmptyWithMessageDataAttribute : EmptyIntWithMessageDataAttribute
{
    public PostPageSizeEmptyWithMessageDataAttribute()
        : base(PostErrorMessages.GetPageSizeEmpty())
    {
    }
}

