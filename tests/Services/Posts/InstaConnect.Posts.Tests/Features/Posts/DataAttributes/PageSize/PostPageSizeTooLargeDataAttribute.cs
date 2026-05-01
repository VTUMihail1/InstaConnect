namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostPageSizeTooLargeDataAttribute : TooLargeIntDataAttribute
{
	public PostPageSizeTooLargeDataAttribute()
		: base(PostConfigurations.PageSizeMaxValue)
	{
	}
}

