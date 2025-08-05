using InstaConnect.Common.Tests.Utilities.DataAttributes.Enums.Empty;
using InstaConnect.PostComments.Common.Features.PostComments.Utilities;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.DataAttributes.SortProperty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentSortPropertyEmptyWithMessageDataAttribute : EmptyEnumWithMessageDataAttribute<PostCommentSortProperty>
{
    public PostCommentSortPropertyEmptyWithMessageDataAttribute()
        : base(PostCommentErrorMessages.GetSortPropertyEmpty())
    {
    }
}
