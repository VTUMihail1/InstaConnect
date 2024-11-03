using InstaConnect.Shared.Common.Models.Enums;

namespace InstaConnect.Shared.Business.Models.Filters;

public abstract record CollectionModel(SortOrder SortOrder, string SortPropertyName, int Page, int PageSize);
