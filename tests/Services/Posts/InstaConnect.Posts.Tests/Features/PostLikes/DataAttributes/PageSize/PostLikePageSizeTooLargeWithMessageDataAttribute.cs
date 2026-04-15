namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikePageSizeTooLargeWithMessageDataAttribute : TooLargeIntWithMessageDataAttribute
{
    public PostLikePageSizeTooLargeWithMessageDataAttribute()
        : base(PostLikeConfigurations.PageSizeMaxValue)
    {
    }
}
