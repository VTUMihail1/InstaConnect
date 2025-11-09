using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikePageSizeTooSmallWithMessageDataAttribute : ValueIntWithMessageDataAttribute
{
    public PostLikePageSizeTooSmallWithMessageDataAttribute()
        : base(PostLikeOutOfBoundsUtilities.PageSizeTooSmall, PostLikeErrorMessages.GetPageSizeTooSmall(PostLikeOutOfBoundsUtilities.PageSizeTooSmall))
    {
    }
}
