using FluentValidation.Results;

using InstaConnect.Common.Domain.Abstractions;
using InstaConnect.Common.Domain.Models;
using InstaConnect.Common.Infrastructure.Helpers;
using InstaConnect.Common.Presentation.Abstractions;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Common.Tests.Utilities;

namespace InstaConnect.Common.Application.Tests.Utilities;
public static class CommonEquals
{
    public static bool Matches(
        this ValidationFailure v,
        string errorMessage)
    {
        return v.ErrorMessage == errorMessage;
    }

    public static bool MatchesCollection<TExpected, TEntity, TKey, TRequest>(
        this ICollection<TExpected> expected,
        ICollection<TEntity> entities,
        Func<TExpected, TKey> expectedKey,
        Func<TEntity, TKey> entityKey,
        Func<TExpected, TEntity, bool> matcher,
        TRequest request,
        Func<TEntity, bool> filter)
        where TRequest : IPaginatableQueryRequest
        where TEntity : IEntity
        where TKey : notnull
    {
        var paginator = PaginatorFactory.Create();
        var offset = paginator.GetOffset(request.Page, request.PageSize);
        var entitiesByKey = entities
            .Where(filter)
            .OrderBy(a => a.CreatedAtUtc)
            .Skip(offset)
            .Take(request.PageSize)
            .ToDictionary(entityKey);

        return expected.Count == entitiesByKey.Count &&
               expected.All(e =>
               entitiesByKey.TryGetValue(expectedKey(e), out var a) &&
               matcher(e, a));
    }

    public static bool MatchesSortedCollection<TExpected, TEntity, TRequest>(
        this ICollection<TExpected> expected,
        ICollection<TEntity> entities,
        Func<TExpected, TEntity, bool> matcher,
        ISortEnumTermTransformer<TEntity> termTransformer,
        TRequest request,
        Func<TEntity, bool> filter)
        where TRequest : IPaginatableQueryRequest
        where TEntity : IEntity
    {
        var paginator = PaginatorFactory.Create();
        var offset = paginator.GetOffset(request.Page, request.PageSize);
        var filteredEntities = entities.Where(filter);
        var sortedEntities = termTransformer
            .Transform(filteredEntities)
            .Skip(offset)
            .Take(request.PageSize)
            .ToList();

        return expected.Count == sortedEntities.Count &&
               expected.Zip(sortedEntities, (e, a) => matcher(e, a))
                       .All(match => match);
    }

    public static bool MatchesCollectionResponse<TResponse, TRequest>(
        this TResponse response,
        int totalCount,
        TRequest request)
            where TRequest : IPaginatableQueryRequest
            where TResponse : ICollectionQueryResponse
    {
        var paginator = PaginatorFactory.Create();

        return response.Page == request.Page &&
               response.PageSize == request.PageSize &&
               response.TotalCount == totalCount &&
               response.HasPreviousPage == paginator.HasPreviousPage(response.Page) &&
               response.HasNextPage == paginator.HasNextPage(response.Page, response.PageSize, response.TotalCount);
    }

    public static bool MatchesSortable<TQuery, TQueryRequest, TSortProperty>(this TQuery query, TQueryRequest request)
        where TQuery : ISortableQuery<TSortProperty>
        where TQueryRequest : ISortableQueryRequest<TSortProperty>
        where TSortProperty : Enum
    {
        return query.Sorting.Order == request.SortOrder &&
               query.Sorting.Property.Equals(request.SortProperty);
    }

    public static bool MatchesPaginatable<TQuery, TQueryRequest>(this TQuery query, TQueryRequest request)
        where TQuery : IPaginatableQuery
        where TQueryRequest : IPaginatableQueryRequest
    {
        return query.Pagination.Page == request.Page &&
               query.Pagination.PageSize == request.PageSize;
    }

    public static bool MatchesIncludable<TQuery, TIncludeProperty>(this TQuery query, CommonIncludeQuery<TIncludeProperty> include)
        where TQuery : IIncludableQuery<TIncludeProperty>
        where TIncludeProperty : Enum
    {
        return query.Include!.Properties.MatchesCollection(include.Properties);
    }
}
