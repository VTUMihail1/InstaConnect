namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikePageSizeTooLargeWithMessageDataAttribute : TooLargeIntWithMessageDataAttribute
{
	public PostCommentLikePageSizeTooLargeWithMessageDataAttribute()
		: base(PostCommentLikeConfigurations.PageSizeMaxValue)
	{
	}
}
