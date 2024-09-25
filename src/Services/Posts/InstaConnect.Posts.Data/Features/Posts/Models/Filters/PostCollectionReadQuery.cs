using InstaConnect.Shared.Data.Models.Enums;

namespace InstaConnect.Posts.Data.Features.Posts.Models.Filters;

public record PostCollectionReadQuery(
    string UserId,
    string UserName,
    string Title,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize);
