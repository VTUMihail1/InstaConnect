namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentPageTooSmallDataAttribute : TooSmallValueIntDataAttribute
{
    public PostCommentPageTooSmallDataAttribute()
        : base(PostCommentConfigurations.PageMinValue)
    {
    }
}

