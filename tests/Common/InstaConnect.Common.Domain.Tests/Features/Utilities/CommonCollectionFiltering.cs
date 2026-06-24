using InstaConnect.Common.Domain.Features.Entities.Abstractions;
using InstaConnect.Common.Domain.Features.Messaging.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Data.Helpers;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;

namespace InstaConnect.Common.Domain.Tests.Features.Utilities;

public static class CommonCollectionFiltering
{
	extension<TEntity>(ICollection<TEntity> entities)
		where TEntity : IEntity
	{
		public IDictionary<TKey, TEntity> FilterToDictionary<TRequest, TPaginationQuery, TKey>(
			Func<TEntity, bool> filter,
			TRequest request,
			Func<TEntity, TKey> entityKey)
			where TRequest : IPaginatableQuery<TPaginationQuery>
			where TPaginationQuery : IPaginationQuery
			where TKey : notnull
		{
			var paginator = new Paginator();
			var offset = paginator.GetOffset(request.Pagination.Page, request.Pagination.PageSize);

			return entities.Where(filter)
				.OrderBy(a => a.CreatedAtUtc)
				.Skip(offset)
				.Take(request.Pagination.PageSize)
				.ToDictionary(entityKey);
		}

		public ICollection<TEntity> Filter<TRequest, TPaginationQuery>(
			ISortEnumTermTransformer<TEntity> termTransformer,
			TRequest request,
			Func<TEntity, bool> filter)
			where TRequest : IPaginatableQuery<TPaginationQuery>
			where TPaginationQuery : IPaginationQuery
		{
			var paginator = new Paginator();
			var offset = paginator.GetOffset(request.Pagination.Page, request.Pagination.PageSize);

			var filteredEntities = entities.Where(filter);

			return [.. termTransformer
				.Transform(filteredEntities)
				.Skip(offset)
				.Take(request.Pagination.PageSize)];
		}

		public ICollection<TResponse> Filter<TRequest, TPaginationQuery, TResponse>(
			Func<TEntity, bool> filter,
			TRequest request,
			Func<TEntity, TResponse> select)
			where TRequest : IPaginatableQuery<TPaginationQuery>
			where TPaginationQuery : IPaginationQuery
		{
			var paginator = new Paginator();
			var offset = paginator.GetOffset(request.Pagination.Page, request.Pagination.PageSize);

			return [.. entities
				.Where(filter)
				.OrderBy(a => a.CreatedAtUtc)
				.Select(select)
				.Skip(offset)
				.Take(request.Pagination.PageSize)];
		}
	}
}
