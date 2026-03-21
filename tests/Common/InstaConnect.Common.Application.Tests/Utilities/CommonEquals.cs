using FluentValidation.Results;

using InstaConnect.Common.Domain.Abstractions;
using InstaConnect.Common.Infrastructure.Helpers;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;

namespace InstaConnect.Common.Application.Tests.Utilities;

public static class CommonEquals
{
    extension(ValidationFailure v)
    {
        public bool Matches(
        string errorMessage)
        {
            return v.ErrorMessage == errorMessage;
        }
    }

    extension<TExpected>(ICollection<TExpected> expected)
    {
        public bool MatchesCollection<TEntity, TKey, TRequest>(
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

        public bool MatchesSortedCollection<TEntity, TRequest>(
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
    }

    extension<TResponse>(TResponse response) where TResponse : ICollectionQueryResponse
    {
        public bool MatchesCollectionResponse<TRequest>(
        int totalCount,
        TRequest request)
            where TRequest : IPaginatableQueryRequest
        {
            var paginator = new Paginator();

            return response.Page == request.Page &&
                   response.PageSize == request.PageSize &&
                   response.TotalCount == totalCount &&
                   response.HasPreviousPage == paginator.HasPreviousPage(response.Page) &&
                   response.HasNextPage == paginator.HasNextPage(response.Page, response.PageSize, response.TotalCount);
        }
    }

    extension<TQuery, TSortTerm, TSortingQuery>(TQuery query)
            where TQuery : ISortableQuery<TSortingQuery, TSortTerm>
            where TSortingQuery : ISortingQuery<TSortTerm>
            where TSortTerm : Enum
    {
        public bool MatchesSortable<TQueryRequest>(TQueryRequest request)
        where TQueryRequest : ISortableQueryRequest<TSortTerm>
        {
            return query.Sorting.Order == request.SortOrder &&
                   query.Sorting.Term.Equals(request.SortTerm);
        }
    }

    extension<TQuery, TPaginationQuery>(TQuery query)
            where TQuery : IPaginatableQuery<TPaginationQuery>
            where TPaginationQuery : IPaginationQuery
    {
        public bool MatchesPaginatable<TQueryRequest>(TQueryRequest request)
        where TQueryRequest : IPaginatableQueryRequest
        {
            return request.Page == request.Page &&
                   request.PageSize == request.PageSize;
        }
    }
}
