using InstaConnect.Shared.Exceptions.EntityOrder.Base;
using InstaConnect.Shared.Models.Base;
using InstaConnect.Shared.Models.Enum;
using System.Linq.Expressions;

namespace InstaConnect.Shared.Extensions
{
    public static class QueryableExtensions
    {
        private const string INVALID_ORDER_PROPERTY_NAME = "Invalid order property name";
        private const string INVALID_ORDER = "Invalid order";

        public static IOrderedQueryable<T> OrderEntities<T>(this IQueryable<T> queryable, SortOrder sortOrder, string orderByPropertyName) where T : class, IBaseEntity
        {
            var orderByProperty = typeof(T).GetProperty(orderByPropertyName);

            if (orderByProperty == null)
            {
                throw new EntityOrderException(INVALID_ORDER_PROPERTY_NAME, InstaConnectStatusCode.BadRequest);
            }

            var parameter = Expression.Parameter(typeof(T));
            var propertyAccess = Expression.Property(parameter, orderByProperty);
            var orderByClause = Expression.Lambda<Func<T, object>>(Expression.Convert(propertyAccess, typeof(object)), parameter);

            if (sortOrder == SortOrder.ASC)
            {
                return queryable.OrderBy(orderByClause);
            }

            if (sortOrder == SortOrder.DESC)
            {
                return queryable.OrderByDescending(orderByClause);
            }

            throw new EntityOrderException(INVALID_ORDER, InstaConnectStatusCode.BadRequest);
        }
    }
}
