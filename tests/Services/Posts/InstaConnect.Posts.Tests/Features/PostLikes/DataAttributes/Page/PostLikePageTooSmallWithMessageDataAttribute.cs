namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikePageTooSmallWithMessageDataAttribute : TooSmallIntWithMessageDataAttribute
{
	public PostLikePageTooSmallWithMessageDataAttribute()
		: base(PostLikeConfigurations.PageMinValue)
	{
	}
}

