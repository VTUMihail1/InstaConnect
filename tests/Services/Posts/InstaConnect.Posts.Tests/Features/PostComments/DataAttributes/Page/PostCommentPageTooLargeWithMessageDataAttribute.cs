namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Page;


[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentPageTooLargeWithMessageDataAttribute : TooLargeIntWithMessageDataAttribute
{
    public PostCommentPageTooLargeWithMessageDataAttribute()
        : base(PostCommentConfigurations.PageMaxValue)
    {
    }
}

