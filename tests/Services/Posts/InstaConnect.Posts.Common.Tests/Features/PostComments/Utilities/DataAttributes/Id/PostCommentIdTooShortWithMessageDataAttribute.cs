using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Length;
using InstaConnect.PostComments.Common.Features.PostComments.Utilities;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentIdTooShortWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public PostCommentIdTooShortWithMessageDataAttribute()
        : base(PostCommentTestValueUtilities.IdTooShort, PostCommentErrorMessages.GetIdTooShort(PostCommentTestValueUtilities.IdTooShort))
    {
    }
}
