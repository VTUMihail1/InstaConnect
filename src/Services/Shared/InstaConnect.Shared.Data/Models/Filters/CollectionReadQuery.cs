using InstaConnect.Shared.Data.Models.Enums;

namespace InstaConnect.Shared.Data.Models.Filters;

public record CollectionReadQuery(SortOrder SortOrder, string SortPropertyName, int Page, int PageSize);
