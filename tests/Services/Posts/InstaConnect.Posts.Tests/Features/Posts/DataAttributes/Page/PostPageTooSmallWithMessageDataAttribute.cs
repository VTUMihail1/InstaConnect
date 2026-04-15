namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostPageTooSmallWithMessageDataAttribute : TooSmallIntWithMessageDataAttribute
{
    public PostPageTooSmallWithMessageDataAttribute()
        : base(PostConfigurations.PageMinValue)
    {
    }
}

