using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Length;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentIdTooShortDataAttribute : LengthStringDataAttribute
{
    public PostCommentIdTooShortDataAttribute()
        : base(PostCommentOutOfBoundsUtilities.IdTooShort)
    {
    }
}
