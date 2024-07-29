using InstaConnect.Shared.Data.Models.Enums;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Posts.Data.Features.PostLikes.Models.Filters;

public record PostLikeCollectionReadQuery(
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize)
    : CollectionReadQuery(SortOrder, SortPropertyName, Page, PageSize);
