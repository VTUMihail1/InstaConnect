using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Length;
using InstaConnect.PostComments.Common.Features.PostComments.Utilities;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentIdTooLongWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public PostCommentIdTooLongWithMessageDataAttribute()
        : base(PostCommentOutOfBoundsUtilities.IdTooLong, PostCommentErrorMessages.GetIdTooLong(PostCommentOutOfBoundsUtilities.IdTooLong))
    {
    }
}
