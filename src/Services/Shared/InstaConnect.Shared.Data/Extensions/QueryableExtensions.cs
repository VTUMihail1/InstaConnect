using System.Linq.Expressions;
using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Shared.Data.Models.Enums;
using InstaConnect.Shared.Data.Models.Pagination;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Shared.Data.Extensions;

public static class QueryableExtensions
{
    public static IOrderedQueryable<T> OrderEntities<T>(
        this IQueryable<T> queryable, 
        SortOrder sortOrder, 
        string orderByPropertyName) where T : class, IBaseEntity
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

    public static async Task<PaginationList<T>> ToPagedList<T>(
        this IQueryable<T> queryable, 
        int page, 
        int pageSize, 
        CancellationToken cancellationToken) where T : class, IBaseEntity
    {
        var totalCount = await queryable.CountAsync(cancellationToken);
        var items = await queryable
            .Skip((page - 1) * pageSize * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginationList<T>(items, totalCount, page, pageSize);
    }
}
