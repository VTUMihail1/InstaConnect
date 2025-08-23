using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Value;
using InstaConnect.PostLikes.Common.Features.PostLikes.Utilities;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikePageSizeTooSmallWithMessageDataAttribute : ValueIntWithMessageDataAttribute
{
    public PostLikePageSizeTooSmallWithMessageDataAttribute()
        : base(PostLikeOutOfBoundsUtilities.PageSizeTooSmall, PostLikeErrorMessages.GetPageSizeTooSmall(PostLikeOutOfBoundsUtilities.PageSizeTooSmall))
    {
    }
}
