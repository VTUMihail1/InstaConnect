namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikePageSizeTooSmallWithMessageDataAttribute : TooSmallIntWithMessageDataAttribute
{
    public PostLikePageSizeTooSmallWithMessageDataAttribute()
        : base(PostLikeConfigurations.PageSizeMinValue)
    {
    }
}
