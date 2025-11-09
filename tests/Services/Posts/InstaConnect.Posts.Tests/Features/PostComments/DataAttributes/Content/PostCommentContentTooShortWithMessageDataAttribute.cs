using InstaConnect.Posts.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Content;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentContentTooShortWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public PostCommentContentTooShortWithMessageDataAttribute()
        : base(PostCommentOutOfBoundsUtilities.ContentTooShort, PostCommentErrorMessages.GetContentTooShort(PostCommentOutOfBoundsUtilities.ContentTooShort))
    {
    }
}

