namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikePageSizeEmptyWithMessageDataAttribute : EmptyIntWithMessageDataAttribute
{
    public PostCommentLikePageSizeEmptyWithMessageDataAttribute()
        : base(PostCommentLikeErrorMessages.GetPageSizeEmpty())
    {
    }
}

