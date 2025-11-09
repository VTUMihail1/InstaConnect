using InstaConnect.Posts.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentPageTooLargeDataAttribute : ValueIntDataAttribute
{
    public PostCommentPageTooLargeDataAttribute()
        : base(PostCommentOutOfBoundsUtilities.PageTooLarge)
    {
    }
}

