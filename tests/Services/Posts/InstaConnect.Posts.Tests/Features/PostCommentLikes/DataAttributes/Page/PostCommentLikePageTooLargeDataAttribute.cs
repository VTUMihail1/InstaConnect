namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikePageTooLargeDataAttribute : TooLargeIntDataAttribute
{
	public PostCommentLikePageTooLargeDataAttribute()
		: base(PostCommentLikeConfigurations.PageMaxValue)
	{
	}
}

