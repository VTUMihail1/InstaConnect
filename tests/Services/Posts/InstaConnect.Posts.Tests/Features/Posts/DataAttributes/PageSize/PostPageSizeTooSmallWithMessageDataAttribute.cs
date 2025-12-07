namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostPageSizeTooSmallWithMessageDataAttribute : TooSmallIntWithMessageDataAttribute
{
    public PostPageSizeTooSmallWithMessageDataAttribute()
        : base(PostConfigurations.PageSizeMinValue)
    {
    }
}
