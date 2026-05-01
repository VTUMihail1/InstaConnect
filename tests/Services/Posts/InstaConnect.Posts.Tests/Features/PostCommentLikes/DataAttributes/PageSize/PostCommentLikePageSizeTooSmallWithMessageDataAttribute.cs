namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikePageSizeTooSmallWithMessageDataAttribute : TooSmallIntWithMessageDataAttribute
{
	public PostCommentLikePageSizeTooSmallWithMessageDataAttribute()
		: base(PostCommentLikeConfigurations.PageSizeMinValue)
	{
	}
}
