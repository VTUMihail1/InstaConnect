namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikePageSizeTooLargeDataAttribute : TooLargeIntDataAttribute
{
	public PostLikePageSizeTooLargeDataAttribute()
		: base(PostLikeConfigurations.PageSizeMaxValue)
	{
	}
}

