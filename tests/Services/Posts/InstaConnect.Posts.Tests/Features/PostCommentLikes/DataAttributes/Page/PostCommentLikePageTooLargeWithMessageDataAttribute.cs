namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.Page;


[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikePageTooLargeWithMessageDataAttribute : TooLargeIntWithMessageDataAttribute
{
	public PostCommentLikePageTooLargeWithMessageDataAttribute()
		: base(PostCommentLikeConfigurations.PageMaxValue)
	{
	}
}

