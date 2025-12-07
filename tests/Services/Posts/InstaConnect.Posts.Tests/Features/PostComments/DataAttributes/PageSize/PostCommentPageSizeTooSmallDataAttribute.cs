namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentPageSizeTooSmallDataAttribute : TooSmallValueIntDataAttribute
{
    public PostCommentPageSizeTooSmallDataAttribute()
        : base(PostCommentConfigurations.PageSizeMinValue)
    {
    }
}

