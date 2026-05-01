namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostPageTooSmallDataAttribute : TooSmallValueIntDataAttribute
{
	public PostPageTooSmallDataAttribute()
		: base(PostConfigurations.PageMinValue)
	{
	}
}

