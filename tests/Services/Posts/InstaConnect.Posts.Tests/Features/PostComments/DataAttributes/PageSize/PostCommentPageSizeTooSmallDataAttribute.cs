using InstaConnect.Posts.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentPageSizeTooSmallDataAttribute : ValueIntDataAttribute
{
    public PostCommentPageSizeTooSmallDataAttribute()
        : base(PostCommentOutOfBoundsUtilities.PageSizeTooSmall)
    {
    }
}

