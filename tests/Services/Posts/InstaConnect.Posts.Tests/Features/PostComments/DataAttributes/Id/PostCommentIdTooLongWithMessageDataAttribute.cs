using InstaConnect.Posts.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentIdTooLongWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public PostCommentIdTooLongWithMessageDataAttribute()
        : base(PostCommentOutOfBoundsUtilities.IdTooLong, PostCommentErrorMessages.GetIdTooLong(PostCommentOutOfBoundsUtilities.IdTooLong))
    {
    }
}
