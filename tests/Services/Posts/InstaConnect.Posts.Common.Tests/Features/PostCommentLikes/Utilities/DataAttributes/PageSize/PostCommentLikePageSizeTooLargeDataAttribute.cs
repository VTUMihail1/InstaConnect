using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Value;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikePageSizeTooLargeDataAttribute : ValueIntDataAttribute
{
    public PostCommentLikePageSizeTooLargeDataAttribute()
        : base(PostCommentLikeOutOfBoundsUtilities.PageSizeTooLarge)
    {
    }
}

