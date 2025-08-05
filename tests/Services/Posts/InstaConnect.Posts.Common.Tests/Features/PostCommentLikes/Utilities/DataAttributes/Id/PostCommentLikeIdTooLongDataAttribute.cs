using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Length;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikeIdTooLongDataAttribute : LengthStringDataAttribute
{
    public PostCommentLikeIdTooLongDataAttribute()
        : base(PostCommentLikeTestValueUtilities.IdTooLong)
    {
    }
}
