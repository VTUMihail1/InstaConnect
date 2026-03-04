using FluentValidation.Results;

using InstaConnect.Common.Domain.Abstractions;
using InstaConnect.Common.Infrastructure.Helpers;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;

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
        var entitiesByKey = entities.FilterToDictionary(filter, request, entityKey);

        return expected.Count == entitiesByKey.Count &&
               expected.Any() &&
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
        var sortedEntities = entities.Filter(termTransformer, request, filter);

        return expected.Count == sortedEntities.Count &&
               expected.Any() &&
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
        var paginator = new Paginator();

        return response.Page == request.Page &&
               response.PageSize == request.PageSize &&
               response.TotalCount == totalCount &&
               response.HasPreviousPage == paginator.HasPreviousPage(response.Page) &&
               response.HasNextPage == paginator.HasNextPage(response.Page, response.PageSize, response.TotalCount);
    }

    public static bool MatchesSortable<TQuery, TQueryRequest, TSortTerm, TSortingQuery>(this TQuery query, TQueryRequest request)
        where TQuery : ISortableQuery<TSortingQuery, TSortTerm>
        where TQueryRequest : ISortableQueryRequest<TSortTerm>
        where TSortingQuery : ISortingQuery<TSortTerm>
        where TSortTerm : Enum
    {
        return query.Sorting.Order == request.SortOrder &&
               query.Sorting.Term.Equals(request.SortTerm);
    }

    public static bool MatchesPaginatable<TQuery, TQueryRequest, TPaginationQuery>(this TQuery query, TQueryRequest request)
        where TQuery : IPaginatableQuery<TPaginationQuery>
        where TPaginationQuery : IPaginationQuery
        where TQueryRequest : IPaginatableQueryRequest
    {
        return query.Pagination.Page == request.Page &&
               query.Pagination.PageSize == request.PageSize;
    }
}
