using System.Linq.Expressions;
using InstaConnect.Shared.Data.Models.Enums;

namespace InstaConnect.Shared.Data.Models.Filters;

public abstract record CollectionReadQuery<T>(
    Expression<Func<T, bool>> Expression,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize);
