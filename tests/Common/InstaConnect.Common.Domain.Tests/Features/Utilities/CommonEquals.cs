using FluentValidation.Results;

using InstaConnect.Common.Domain.Features.AccessTokens.Models;
using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Domain.Features.Entities.Abstractions;
using InstaConnect.Common.Domain.Features.Messaging.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Data.Helpers;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;

namespace InstaConnect.Common.Domain.Tests.Features.Utilities;

public static class CommonEquals
{
	extension(AccessToken response)
	{
		public bool Matches()
		{
			return response.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   response.ExpiresAtUtc != default;
		}
	}

	extension(ValidationFailure v)
	{
		public bool Matches(
		string errorMessage)
		{
			return v.ErrorMessage.EqualsOrdinalIgnoreCase(errorMessage);
		}
	}

	extension<TExpected>(ICollection<TExpected> expected)
	{
		public bool MatchesCollection<TEntity, TKey, TRequest, TPaginationQuery>(
		ICollection<TEntity> entities,
		Func<TExpected, TKey> expectedKey,
		Func<TEntity, TKey> entityKey,
		Func<TExpected, TEntity, bool> matcher,
		TRequest request,
		Func<TEntity, bool> filter)
		where TRequest : IPaginatableQuery<TPaginationQuery>
		where TPaginationQuery : IPaginationQuery
		where TEntity : IEntity
		where TKey : notnull
		{
			var entitiesByKey = entities.FilterToDictionary<TEntity, TRequest, TPaginationQuery, TKey>(filter, request, entityKey);

			return expected.Count == entitiesByKey.Count &&
				   expected.Any() &&
				   expected.All(e =>
				   entitiesByKey.TryGetValue(expectedKey(e), out var a) &&
				   matcher(e, a));
		}

		public bool MatchesSortedCollection<TEntity, TRequest, TPaginationQuery>(
			ICollection<TEntity> entities,
			Func<TExpected, TEntity, bool> matcher,
			ISortEnumTermTransformer<TEntity> termTransformer,
			TRequest request,
			Func<TEntity, bool> filter)
			where TRequest : IPaginatableQuery<TPaginationQuery>
			where TPaginationQuery : IPaginationQuery
			where TEntity : IEntity
		{
			var sortedEntities = entities.Filter<TEntity, TRequest, TPaginationQuery>(termTransformer, request, filter);

			return expected.Count == sortedEntities.Count &&
				   expected.Any() &&
				   expected.Zip(sortedEntities, (e, a) => matcher(e, a))
						   .All(match => match);
		}
	}

	extension<TResponse>(TResponse response) where TResponse : ICollectionResponse
	{
		public bool MatchesCollectionResponse<TRequest, TPaginationQuery>(
		int totalCount,
		TRequest request)
			where TRequest : IPaginatableQuery<TPaginationQuery>
			where TPaginationQuery : IPaginationQuery
		{
			var paginator = new Paginator();

			return response.Page == request.Pagination.Page &&
				   response.PageSize == request.Pagination.PageSize &&
				   response.TotalCount == totalCount &&
				   response.HasPreviousPage == paginator.HasPreviousPage(response.Page) &&
				   response.HasNextPage == paginator.HasNextPage(response.Page, response.PageSize, response.TotalCount);
		}
	}
}
