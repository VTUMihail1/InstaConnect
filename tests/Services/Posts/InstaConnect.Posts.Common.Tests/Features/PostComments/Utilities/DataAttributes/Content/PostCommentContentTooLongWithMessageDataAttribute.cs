using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Length;
using InstaConnect.PostComments.Common.Features.PostComments.Utilities;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.DataAttributes.Content;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentContentTooLongWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public PostCommentContentTooLongWithMessageDataAttribute()
        : base(PostCommentOutOfBoundsUtilities.ContentTooLong, PostCommentErrorMessages.GetContentTooLong(PostCommentOutOfBoundsUtilities.ContentTooLong))
    {
    }
}

