using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Value;
using InstaConnect.PostCommentLikes.Common.Features.PostCommentLikes.Utilities;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.DataAttributes.Page;


[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikePageTooLargeWithMessageDataAttribute : ValueIntWithMessageDataAttribute
{
    public PostCommentLikePageTooLargeWithMessageDataAttribute()
        : base(PostCommentLikeOutOfBoundsUtilities.PageTooLarge, PostCommentLikeErrorMessages.GetPageTooLarge(PostCommentLikeOutOfBoundsUtilities.PageTooLarge))
    {
    }
}

