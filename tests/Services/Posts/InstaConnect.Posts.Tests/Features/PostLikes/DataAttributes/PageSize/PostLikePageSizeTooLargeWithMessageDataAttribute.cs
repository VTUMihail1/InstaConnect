using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikePageSizeTooLargeWithMessageDataAttribute : ValueIntWithMessageDataAttribute
{
    public PostLikePageSizeTooLargeWithMessageDataAttribute()
        : base(PostLikeOutOfBoundsUtilities.PageSizeTooLarge, PostLikeErrorMessages.GetPageSizeTooLarge(PostLikeOutOfBoundsUtilities.PageSizeTooLarge))
    {
    }
}
