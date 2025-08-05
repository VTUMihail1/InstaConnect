using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Value;
using InstaConnect.PostComments.Common.Features.PostComments.Utilities;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentPageSizeTooLargeWithMessageDataAttribute : ValueIntWithMessageDataAttribute
{
    public PostCommentPageSizeTooLargeWithMessageDataAttribute()
        : base(PostCommentTestValueUtilities.PageSizeTooLarge, PostCommentErrorMessages.GetPageSizeTooLarge(PostCommentTestValueUtilities.PageSizeTooLarge))
    {
    }
}
