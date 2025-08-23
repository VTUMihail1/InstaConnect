using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Length;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentContentTooLongDataAttribute : LengthStringDataAttribute
{
    public PostCommentContentTooLongDataAttribute()
        : base(PostCommentOutOfBoundsUtilities.ContentTooLong)
    {
    }
}
