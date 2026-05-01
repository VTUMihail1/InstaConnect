namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikePageTooLargeDataAttribute : TooLargeIntDataAttribute
{
	public PostLikePageTooLargeDataAttribute()
		: base(PostLikeConfigurations.PageMaxValue)
	{
	}
}

