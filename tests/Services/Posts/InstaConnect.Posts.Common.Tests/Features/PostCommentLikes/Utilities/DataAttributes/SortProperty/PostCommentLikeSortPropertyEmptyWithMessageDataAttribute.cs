using InstaConnect.Common.Tests.Utilities.DataAttributes.Enums.Empty;
using InstaConnect.PostCommentLikes.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.DataAttributes.SortProperty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikeSortPropertyEmptyWithMessageDataAttribute : EmptyEnumWithMessageDataAttribute<PostCommentLikeSortProperty>
{
    public PostCommentLikeSortPropertyEmptyWithMessageDataAttribute()
        : base(PostCommentLikeErrorMessages.GetSortPropertyEmpty())
    {
    }
}
