namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostPageSizeTooSmallDataAttribute : TooSmallValueIntDataAttribute
{
	public PostPageSizeTooSmallDataAttribute()
		: base(PostConfigurations.PageSizeMinValue)
	{
	}
}

