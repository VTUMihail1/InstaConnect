using InstaConnect.Posts.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentPageTooSmallDataAttribute : ValueIntDataAttribute
{
    public PostCommentPageTooSmallDataAttribute()
        : base(PostCommentOutOfBoundsUtilities.PageTooSmall)
    {
    }
}

