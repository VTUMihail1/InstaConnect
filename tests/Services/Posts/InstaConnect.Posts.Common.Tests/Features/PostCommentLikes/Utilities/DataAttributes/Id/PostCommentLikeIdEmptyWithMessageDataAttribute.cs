using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Empty;
using InstaConnect.PostCommentLikes.Common.Features.PostCommentLikes.Utilities;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikeIdEmptyWithMessageDataAttribute : EmptyStringWithMessageDataAttribute
{
    public PostCommentLikeIdEmptyWithMessageDataAttribute()
        : base(PostCommentLikeErrorMessages.GetIdEmpty())
    {
    }
}

