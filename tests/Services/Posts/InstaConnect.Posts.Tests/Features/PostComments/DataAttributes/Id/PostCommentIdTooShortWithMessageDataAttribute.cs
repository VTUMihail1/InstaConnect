using InstaConnect.Posts.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentIdTooShortWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public PostCommentIdTooShortWithMessageDataAttribute()
        : base(PostCommentOutOfBoundsUtilities.IdTooShort, PostCommentErrorMessages.GetIdTooShort(PostCommentOutOfBoundsUtilities.IdTooShort))
    {
    }
}
