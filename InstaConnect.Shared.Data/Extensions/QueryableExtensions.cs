using InstaConnect.Shared.Data.Enum;
using InstaConnect.Shared.Data.Models.Base;
using System.Linq.Expressions;

namespace InstaConnect.Shared.Data.Extensions;

public static class QueryableExtensions
{
    public static IOrderedQueryable<T> OrderEntities<T>(this IQueryable<T> queryable, SortOrder sortOrder, string orderByPropertyName) where T : class, IBaseEntity
    {
        var orderByProperty = typeof(T).GetProperty(orderByPropertyName);
        var parameter = Expression.Parameter(typeof(T));
        var propertyAccess = Expression.Property(parameter, orderByProperty!);
        var orderByClause = Expression.Lambda<Func<T, object>>(Expression.Convert(propertyAccess, typeof(object)), parameter);

        if (sortOrder == SortOrder.DESC)
        {
            return queryable.OrderByDescending(orderByClause);
        }

        return queryable.OrderBy(orderByClause);
    }
}
