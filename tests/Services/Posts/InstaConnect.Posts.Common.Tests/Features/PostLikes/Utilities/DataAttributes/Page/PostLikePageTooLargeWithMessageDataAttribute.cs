using InstaConnect.Common.Tests.Utilities.Types.Ints.Value;
using InstaConnect.PostLikes.Common.Features.PostLikes.Utilities;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.DataAttributes.Page;


[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikePageTooLargeWithMessageDataAttribute : ValueIntWithMessageDataAttribute
{
    public PostLikePageTooLargeWithMessageDataAttribute()
        : base(PostLikeTestValueUtilities.PageTooLarge, PostLikeErrorMessages.GetPageTooLarge(PostLikeTestValueUtilities.PageTooLarge))
    {
    }
}

