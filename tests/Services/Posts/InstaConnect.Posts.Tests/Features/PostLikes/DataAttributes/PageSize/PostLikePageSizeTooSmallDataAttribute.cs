namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikePageSizeTooSmallDataAttribute : TooSmallValueIntDataAttribute
{
    public PostLikePageSizeTooSmallDataAttribute()
        : base(PostLikeConfigurations.PageSizeMinValue)
    {
    }
}

