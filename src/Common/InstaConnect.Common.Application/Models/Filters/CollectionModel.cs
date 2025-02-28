using InstaConnect.Common.Models.Enums;

namespace InstaConnect.Common.Application.Models.Filters;

public abstract record CollectionModel(SortOrder SortOrder, string SortPropertyName, int Page, int PageSize);
