namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentPageSizeTooLargeWithMessageDataAttribute : TooLargeIntWithMessageDataAttribute
{
    public PostCommentPageSizeTooLargeWithMessageDataAttribute()
        : base(PostCommentConfigurations.PageSizeMaxValue)
    {
    }
}
