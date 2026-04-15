namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikePageTooSmallDataAttribute : TooSmallValueIntDataAttribute
{
    public PostCommentLikePageTooSmallDataAttribute()
        : base(PostCommentLikeConfigurations.PageMinValue)
    {
    }
}

