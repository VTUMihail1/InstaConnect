using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Domain.Features.Entities.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Data.Helpers;
using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;
using InstaConnect.Common.Presentation.Features.Messaging.Abstractions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;

using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Common.Presentation.Tests.Features.Utilities;

public static class CommonEquals
{
    extension(ApplicationProblemDetails d)
    {
        public bool Matches(int statusCode, string detail)
        {
            return d.Status == statusCode &&
                   detail.EqualsOrdinalIgnoreCase(d.Detail);
        }

        public bool Matches(int statusCode, string detail, string errorMessage)
        {
            return d.Status == statusCode &&
                   detail.EqualsOrdinalIgnoreCase(d.Detail) &&
                   d.Errors!.All(e => e == errorMessage);
        }
    }

    extension(ObjectResult s)
    {
        public bool Matches(int statusCode)
        {
            return s.StatusCode == statusCode;
        }
    }

    extension(StatusCodeResult s)
    {
        public bool Matches(int statusCode)
        {
            return s.StatusCode == statusCode;
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
            where TRequest : IPaginatableApiRequest
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
            where TRequest : IPaginatableApiRequest
            where TEntity : IEntity
        {
            var sortedEntities = entities.Filter(termTransformer, request, filter);

            return expected.Count == sortedEntities.Count &&
                   expected.Any() &&
                   expected.Zip(sortedEntities, (e, a) => matcher(e, a))
                           .All(match => match);
        }
    }

    extension<TResponse>(TResponse response)
        where TResponse : ICollectionApiResponse
    {
        public bool MatchesCollectionResponse<TRequest>(int totalCount, TRequest request)
            where TRequest : IPaginatableApiRequest
        {
            var paginator = new Paginator();

            return response.Page == request.Page &&
                   response.PageSize == request.PageSize &&
                   response.TotalCount == totalCount &&
                   response.HasPreviousPage == paginator.HasPreviousPage(response.Page) &&
                   response.HasNextPage == paginator.HasNextPage(response.Page, response.PageSize, response.TotalCount);
        }
    }

    extension<TQueryRequest, TSortTerm>(TQueryRequest query)
            where TQueryRequest : ISortableQueryRequest<TSortTerm>
            where TSortTerm : Enum
    {
        public bool MatchesSortable<TApiRequest>(TApiRequest request)
            where TApiRequest : ISortableApiRequest<TSortTerm>
        {
            return query.SortOrder == request.SortOrder &&
                   query.SortTerm.Equals(request.SortTerm);
        }
    }

    extension<TQueryRequest>(TQueryRequest query)
            where TQueryRequest : IPaginatableQueryRequest
    {
        public bool MatchesPaginatable<TApiRequest>(TApiRequest request)
            where TApiRequest : IPaginatableApiRequest
        {
            return query.Page == request.Page &&
                   query.PageSize == request.PageSize;
        }
    }
}
