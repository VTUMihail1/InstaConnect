using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Value;
using InstaConnect.PostCommentLikes.Common.Features.PostCommentLikes.Utilities;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikePageTooSmallWithMessageDataAttribute : ValueIntWithMessageDataAttribute
{
    public PostCommentLikePageTooSmallWithMessageDataAttribute()
        : base(PostCommentLikeTestValueUtilities.PageTooSmall, PostCommentLikeErrorMessages.GetPageTooSmall(PostCommentLikeTestValueUtilities.PageTooSmall))
    {
    }
}

