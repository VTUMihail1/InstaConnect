using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Empty;
using InstaConnect.PostLikes.Common.Features.PostLikes.Utilities;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikePageSizeEmptyWithMessageDataAttribute : EmptyIntWithMessageDataAttribute
{
    public PostLikePageSizeEmptyWithMessageDataAttribute()
        : base(PostLikeErrorMessages.GetPageSizeEmpty())
    {
    }
}

