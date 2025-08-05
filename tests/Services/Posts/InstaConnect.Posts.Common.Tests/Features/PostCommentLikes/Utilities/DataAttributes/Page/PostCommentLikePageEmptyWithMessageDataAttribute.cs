using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Empty;
using InstaConnect.PostCommentLikes.Common.Features.PostCommentLikes.Utilities;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikePageEmptyWithMessageDataAttribute : EmptyIntWithMessageDataAttribute
{
    public PostCommentLikePageEmptyWithMessageDataAttribute()
        : base(PostCommentLikeErrorMessages.GetPageEmpty())
    {
    }
}
