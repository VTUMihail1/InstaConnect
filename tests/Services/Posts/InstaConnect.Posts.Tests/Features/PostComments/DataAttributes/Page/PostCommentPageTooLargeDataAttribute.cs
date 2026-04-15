namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentPageTooLargeDataAttribute : TooLargeIntDataAttribute
{
    public PostCommentPageTooLargeDataAttribute()
        : base(PostCommentConfigurations.PageMaxValue)
    {
    }
}

