using InstaConnect.Posts.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Content;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentContentTooLongDataAttribute : LengthStringDataAttribute
{
    public PostCommentContentTooLongDataAttribute()
        : base(PostCommentOutOfBoundsUtilities.ContentTooLong)
    {
    }
}
