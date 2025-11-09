namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikePageEmptyWithMessageDataAttribute : EmptyIntWithMessageDataAttribute
{
    public PostCommentLikePageEmptyWithMessageDataAttribute()
        : base(PostCommentLikeErrorMessages.GetPageEmpty())
    {
    }
}
