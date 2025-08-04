using InstaConnect.Common.Tests.Utilities.Types.Enums.Empty;
using InstaConnect.PostLikes.Common.Features.PostLikes.Utilities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.DataAttributes.SortProperty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikeSortPropertyEmptyWithMessageDataAttribute : EmptyEnumWithMessageDataAttribute<PostLikeSortProperty>
{
    public PostLikeSortPropertyEmptyWithMessageDataAttribute()
        : base(PostLikeErrorMessages.GetSortPropertyEmpty())
    {
    }
}
