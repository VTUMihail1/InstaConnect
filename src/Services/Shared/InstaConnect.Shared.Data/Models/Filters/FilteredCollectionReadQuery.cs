using System.Linq.Expressions;
using InstaConnect.Shared.Data.Models.Enums;

namespace InstaConnect.Shared.Data.Models.Filters;

public abstract record FilteredCollectionReadQuery<T>(
    Expression<Func<T, bool>> Expression,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize)
    : CollectionReadQuery(SortOrder, SortPropertyName, Page, PageSize);
