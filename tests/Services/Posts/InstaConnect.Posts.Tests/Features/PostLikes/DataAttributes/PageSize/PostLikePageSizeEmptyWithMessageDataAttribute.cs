namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikePageSizeEmptyWithMessageDataAttribute : EmptyIntWithMessageDataAttribute
{
    public PostLikePageSizeEmptyWithMessageDataAttribute()
        : base(PostLikeErrorMessages.GetPageSizeEmpty())
    {
    }
}

