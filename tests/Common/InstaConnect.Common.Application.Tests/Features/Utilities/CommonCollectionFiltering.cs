using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Entities.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Data.Helpers;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;

namespace InstaConnect.Common.Application.Tests.Features.Utilities;

public static class CommonCollectionFiltering
{
	extension<TEntity>(ICollection<TEntity> entities)
		where TEntity : IEntity
	{
		public IDictionary<TKey, TEntity> FilterToDictionary<TRequest, TKey>(
			Func<TEntity, bool> filter,
			TRequest request,
			Func<TEntity, TKey> entityKey)
			where TRequest : IPaginatableQueryRequest
			where TKey : notnull
		{
			var paginator = new Paginator();
			var offset = paginator.GetOffset(request.Page, request.PageSize);

			return entities.Where(filter)
				.OrderBy(a => a.CreatedAtUtc)
				.Skip(offset)
				.Take(request.PageSize)
				.ToDictionary(entityKey);
		}

		public ICollection<TEntity> Filter<TRequest>(
			ISortEnumTermTransformer<TEntity> termTransformer,
			TRequest request,
			Func<TEntity, bool> filter)
			where TRequest : IPaginatableQueryRequest
		{
			var paginator = new Paginator();
			var offset = paginator.GetOffset(request.Page, request.PageSize);

			var filteredEntities = entities.Where(filter);

			return [.. termTransformer
				.Transform(filteredEntities)
				.Skip(offset)
				.Take(request.PageSize)];
		}

		public ICollection<TResponse> Filter<TRequest, TResponse>(
			Func<TEntity, bool> filter,
			TRequest request,
			Func<TEntity, TResponse> select)
			where TRequest : IPaginatableQueryRequest
		{
			var paginator = new Paginator();
			var offset = paginator.GetOffset(request.Page, request.PageSize);

			return [.. entities
				.Where(filter)
				.OrderBy(a => a.CreatedAtUtc)
				.Select(select)
				.Skip(offset)
				.Take(request.PageSize)];
		}
	}
}
