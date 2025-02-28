using InstaConnect.Common.Models.Enums;

namespace InstaConnect.Posts.Domain.Features.Posts.Models.Filters;

public record PostCollectionReadQuery(
    string UserId,
    string UserName,
    string Title,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize);
