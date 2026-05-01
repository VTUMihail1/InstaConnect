namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikePageSizeTooSmallDataAttribute : TooSmallValueIntDataAttribute
{
	public PostCommentLikePageSizeTooSmallDataAttribute()
		: base(PostCommentLikeConfigurations.PageSizeMinValue)
	{
	}
}

