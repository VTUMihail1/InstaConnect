using InstaConnect.Posts.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Content;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentContentTooLongWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public PostCommentContentTooLongWithMessageDataAttribute()
        : base(PostCommentOutOfBoundsUtilities.ContentTooLong, PostCommentErrorMessages.GetContentTooLong(PostCommentOutOfBoundsUtilities.ContentTooLong))
    {
    }
}

