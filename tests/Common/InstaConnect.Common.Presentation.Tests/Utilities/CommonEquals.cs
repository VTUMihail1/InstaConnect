using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Domain.Abstractions;
using InstaConnect.Common.Infrastructure.Helpers;
using InstaConnect.Common.Presentation.Models;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;

using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Common.Presentation.Tests.Utilities;
public static class CommonEquals
{
    public static bool Matches(
        this ApplicationProblemDetails d,
        int statusCode,
        string detail)
    {
        return d.Status == statusCode &&
               d.Detail == detail;
    }

    public static bool Matches(
        this ApplicationProblemDetails d,
        int statusCode,
        string detail,
        string errorMessage)
    {
        return d.Status == statusCode &&
               d.Detail == detail &&
               d.Errors!.All(e => e == errorMessage);
    }

    public static bool Matches(
        this ObjectResult s,
        int statusCode)
    {
        return s.StatusCode == statusCode;
    }

    public static bool Matches(
        this StatusCodeResult s,
        int statusCode)
    {
        return s.StatusCode == statusCode;
    }

    public static bool MatchesCollection<TExpected, TEntity, TKey, TRequest>(
        this ICollection<TExpected> expected,
        ICollection<TEntity> entities,
        Func<TExpected, TKey> expectedKey,
        Func<TEntity, TKey> entityKey,
        Func<TExpected, TEntity, bool> matcher,
        TRequest request,
        Func<TEntity, bool> filter)
        where TRequest : IPaginatableApiRequest
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
        where TRequest : IPaginatableApiRequest
        where TEntity : IEntity
    {
        var paginator = PaginatorFactory.Create();
        var offset = paginator.GetOffset(request.Page, request.PageSize);
        var filteredActual = entities.Where(filter);
        var sortedEntities = termTransformer
            .Transform(filteredActual)
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
            where TRequest : IPaginatableApiRequest
            where TResponse : ICollectionApiResponse
    {
        var paginator = PaginatorFactory.Create();

        return response.Page == request.Page &&
               response.PageSize == request.PageSize &&
               response.TotalCount == totalCount &&
               response.HasPreviousPage == paginator.HasPreviousPage(response.Page) &&
               response.HasNextPage == paginator.HasNextPage(response.Page, response.PageSize, response.TotalCount);
    }

    public static bool MatchesSortable<TQueryRequest, TApiRequest, TSortProperty>(this TQueryRequest query, TApiRequest request)
        where TQueryRequest : ISortableQueryRequest<TSortProperty>
        where TApiRequest : ISortableApiRequest<TSortProperty>
        where TSortProperty : Enum
    {
        return query.SortOrder == request.SortOrder &&
               query.SortProperty.Equals(request.SortProperty);
    }

    public static bool MatchesPaginatable<TQueryRequest, TApiRequest>(this TQueryRequest query, TApiRequest request)
        where TQueryRequest : IPaginatableQueryRequest
        where TApiRequest : IPaginatableApiRequest
    {
        return query.Page == request.Page &&
               query.PageSize == request.PageSize;
    }
}
