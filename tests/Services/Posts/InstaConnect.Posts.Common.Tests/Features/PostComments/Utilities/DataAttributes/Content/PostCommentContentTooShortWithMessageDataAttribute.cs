using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Length;
using InstaConnect.PostComments.Common.Features.PostComments.Utilities;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.DataAttributes.Content;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentContentTooShortWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public PostCommentContentTooShortWithMessageDataAttribute()
        : base(PostCommentOutOfBoundsUtilities.ContentTooShort, PostCommentErrorMessages.GetContentTooShort(PostCommentOutOfBoundsUtilities.ContentTooShort))
    {
    }
}

