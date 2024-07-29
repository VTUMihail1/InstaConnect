using InstaConnect.Shared.Data.Models.Enums;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Identity.Data.Features.Users.Models.Filters;

public record UserCollectionReadQuery(
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize)
    : CollectionReadQuery(SortOrder, SortPropertyName, Page, PageSize);
