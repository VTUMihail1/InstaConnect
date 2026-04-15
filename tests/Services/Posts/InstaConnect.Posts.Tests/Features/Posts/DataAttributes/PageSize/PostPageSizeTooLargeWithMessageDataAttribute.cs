namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostPageSizeTooLargeWithMessageDataAttribute : TooLargeIntWithMessageDataAttribute
{
    public PostPageSizeTooLargeWithMessageDataAttribute()
        : base(PostConfigurations.PageSizeMaxValue)
    {
    }
}
