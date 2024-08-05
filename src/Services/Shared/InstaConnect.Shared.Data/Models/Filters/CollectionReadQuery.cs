using InstaConnect.Shared.Data.Models.Enums;

namespace InstaConnect.Shared.Data.Models.Filters;

public abstract record CollectionReadQuery(SortOrder SortOrder, string SortPropertyName, int Page, int PageSize);
