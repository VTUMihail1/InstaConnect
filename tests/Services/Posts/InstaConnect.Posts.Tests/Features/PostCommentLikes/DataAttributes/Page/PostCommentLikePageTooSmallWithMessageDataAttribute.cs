namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikePageTooSmallWithMessageDataAttribute : TooSmallIntWithMessageDataAttribute
{
	public PostCommentLikePageTooSmallWithMessageDataAttribute()
		: base(PostCommentLikeConfigurations.PageMinValue)
	{
	}
}

