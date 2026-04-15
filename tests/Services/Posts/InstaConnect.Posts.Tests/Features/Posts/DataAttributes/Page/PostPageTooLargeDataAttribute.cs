namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostPageTooLargeDataAttribute : TooLargeIntDataAttribute
{
    public PostPageTooLargeDataAttribute()
        : base(PostConfigurations.PageMaxValue)
    {
    }
}

