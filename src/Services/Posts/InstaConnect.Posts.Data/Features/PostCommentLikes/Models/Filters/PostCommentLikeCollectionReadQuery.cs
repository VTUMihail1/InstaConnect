using InstaConnect.Shared.Data.Models.Enums;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Posts.Data.Features.PostCommentLikes.Models.Filters;

public record PostCommentLikeCollectionReadQuery(
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize)
    : CollectionReadQuery(SortOrder, SortPropertyName, Page, PageSize);
