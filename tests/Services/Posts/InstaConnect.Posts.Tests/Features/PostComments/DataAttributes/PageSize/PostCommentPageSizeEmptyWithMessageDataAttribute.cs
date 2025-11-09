namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentPageSizeEmptyWithMessageDataAttribute : EmptyIntWithMessageDataAttribute
{
    public PostCommentPageSizeEmptyWithMessageDataAttribute()
        : base(PostCommentErrorMessages.GetPageSizeEmpty())
    {
    }
}

