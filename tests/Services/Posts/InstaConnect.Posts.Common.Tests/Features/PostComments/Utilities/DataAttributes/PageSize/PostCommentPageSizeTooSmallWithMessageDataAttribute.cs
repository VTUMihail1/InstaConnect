using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Value;
using InstaConnect.PostComments.Common.Features.PostComments.Utilities;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentPageSizeTooSmallWithMessageDataAttribute : ValueIntWithMessageDataAttribute
{
    public PostCommentPageSizeTooSmallWithMessageDataAttribute()
        : base(PostCommentTestValueUtilities.PageSizeTooSmall, PostCommentErrorMessages.GetPageSizeTooSmall(PostCommentTestValueUtilities.PageSizeTooSmall))
    {
    }
}
