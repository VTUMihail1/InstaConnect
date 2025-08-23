using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Value;
using InstaConnect.PostCommentLikes.Common.Features.PostCommentLikes.Utilities;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikePageSizeTooSmallWithMessageDataAttribute : ValueIntWithMessageDataAttribute
{
    public PostCommentLikePageSizeTooSmallWithMessageDataAttribute()
        : base(PostCommentLikeOutOfBoundsUtilities.PageSizeTooSmall, PostCommentLikeErrorMessages.GetPageSizeTooSmall(PostCommentLikeOutOfBoundsUtilities.PageSizeTooSmall))
    {
    }
}
