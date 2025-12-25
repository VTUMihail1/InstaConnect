using InstaConnect.Common.Domain.Abstractions;
using InstaConnect.Common.Infrastructure.Helpers;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;

namespace InstaConnect.Common.Application.Tests.Utilities;
public static class CommonCollectionFiltering
{
    public static IDictionary<TKey, TEntity> FilterToDictionary<TEntity, TRequest, TKey>(
        this ICollection<TEntity> entities,
        Func<TEntity, bool> filter,
        TRequest request,
        Func<TEntity, TKey> entityKey)
        where TEntity : IEntity
        where TRequest : IPaginatableQueryRequest
        where TKey : notnull
    {
        var paginator = PaginatorFactory.Create();
        var offset = paginator.GetOffset(request.Page, request.PageSize);

        return entities.Where(filter)
            .OrderBy(a => a.CreatedAtUtc)
            .Skip(offset)
            .Take(request.PageSize)
            .ToDictionary(entityKey);
    }

    public static ICollection<TEntity> Filter<TEntity, TRequest>(
        this ICollection<TEntity> entities,
        Func<TEntity, bool> filter,
        TRequest request)
        where TEntity : IEntity
        where TRequest : IPaginatableQueryRequest
    {
        var paginator = PaginatorFactory.Create();
        var offset = paginator.GetOffset(request.Page, request.PageSize);

        return entities
            .Where(filter)
            .OrderBy(a => a.CreatedAtUtc)
            .Skip(offset)
            .Take(request.PageSize)
            .ToList();
    }

    public static ICollection<TEntity> Filter<TEntity, TRequest>(
        this ICollection<TEntity> entities,
        ISortEnumTermTransformer<TEntity> termTransformer,
        TRequest request,
        Func<TEntity, bool> filter)
        where TRequest : IPaginatableQueryRequest
        where TEntity : IEntity
    {
        var paginator = PaginatorFactory.Create();
        var offset = paginator.GetOffset(request.Page, request.PageSize);

        var filteredEntities = entities.Where(filter);
        return termTransformer
            .Transform(filteredEntities)
            .Skip(offset)
            .Take(request.PageSize)
            .ToList();
    }
}
