namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentPageTooSmallWithMessageDataAttribute : TooSmallIntWithMessageDataAttribute
{
    public PostCommentPageTooSmallWithMessageDataAttribute()
        : base(PostCommentConfigurations.PageMinValue)
    {
    }
}

