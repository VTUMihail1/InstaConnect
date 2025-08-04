using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Empty;
using InstaConnect.PostLikes.Common.Features.PostLikes.Utilities;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikePageEmptyWithMessageDataAttribute : EmptyIntWithMessageDataAttribute
{
    public PostLikePageEmptyWithMessageDataAttribute()
        : base(PostLikeErrorMessages.GetPageEmpty())
    {
    }
}
