using InstaConnect.Common.Tests.Utilities.Types.Ints.Value;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikePageTooLargeDataAttribute : ValueIntDataAttribute
{
    public PostLikePageTooLargeDataAttribute()
        : base(PostLikeTestValueUtilities.PageTooLarge)
    {
    }
}

