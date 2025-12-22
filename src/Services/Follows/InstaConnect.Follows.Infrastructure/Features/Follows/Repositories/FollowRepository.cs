using InstaConnect.Common.Domain.Models;
using InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Repositories;

internal class FollowRepository : IFollowRepository
{
    private readonly IPaginator _paginator;
    private readonly IFollowsContext _followsContext;
    private readonly ISortOrderFactory _sortOrderFactory;
    private readonly IFollowCollectionFactory _followCollectionFactory;
    private readonly IFollowIncludePropertyFactory _followIncludePropertyFactory;
    private readonly IFollowByFollowerSortPropertyFactory _followByFollowerSortPropertyFactory;
    private readonly IFollowByFollowingSortPropertyFactory _followByFollowingSortPropertyFactory;

    public FollowRepository(
        IPaginator paginator,
        IFollowsContext followsContext,
        ISortOrderFactory sortOrderFactory,
        IFollowCollectionFactory followCollectionFactory,
        IFollowIncludePropertyFactory followIncludePropertyFactory,
        IFollowByFollowerSortPropertyFactory followByFollowerSortPropertyFactory,
        IFollowByFollowingSortPropertyFactory followByFollowingSortPropertyFactory)
    {
        _paginator = paginator;
        _followsContext = followsContext;
        _sortOrderFactory = sortOrderFactory;
        _followCollectionFactory = followCollectionFactory;
        _followIncludePropertyFactory = followIncludePropertyFactory;
        _followByFollowerSortPropertyFactory = followByFollowerSortPropertyFactory;
        _followByFollowingSortPropertyFactory = followByFollowingSortPropertyFactory;
    }

    public async Task<FollowCollection> GetAllByFollowerAsync(
        FollowByFollowerFilterQuery filter,
        CommonSortingQuery<FollowByFollowerSortProperty> sorting,
        CommonPaginationQuery pagination,
        CommonIncludeQuery<FollowIncludeProperty>? include,
        CancellationToken cancellationToken)
    {
        var match = filter.GetFilter();
        var sortOrder = _sortOrderFactory.Create(sorting.Order);
        var sortProperty = _followByFollowerSortPropertyFactory.Create(sorting.Property);
        var includeProperties = _followIncludePropertyFactory.Create(include?.Properties);
        var offset = _paginator.GetOffset(pagination.Page, pagination.PageSize);

        var pipeline = _followsContext
            .Follows
            .Aggregate()
            .Includes(includeProperties)
            .Match(match);

        var entities = await pipeline
            .Sort(sortOrder.Sort(sortProperty.Property))
            .Skip(offset)
            .Limit(pagination.PageSize)
            .ToListAsync(cancellationToken);

        var totalCount = await _followsContext.Follows.GetCount(match, cancellationToken);
        var collectionEntities = _followCollectionFactory.Create(entities, totalCount, pagination);

        return collectionEntities;
    }

    public async Task<FollowCollection> GetAllByFollowingAsync(
        FollowByFollowingFilterQuery filter,
        CommonSortingQuery<FollowByFollowingSortProperty> sorting,
        CommonPaginationQuery pagination,
        CommonIncludeQuery<FollowIncludeProperty>? include,
        CancellationToken cancellationToken)
    {
        var match = filter.GetFilter();
        var sortOrder = _sortOrderFactory.Create(sorting.Order);
        var sortProperty = _followByFollowingSortPropertyFactory.Create(sorting.Property);
        var includeProperties = _followIncludePropertyFactory.Create(include?.Properties);
        var offset = _paginator.GetOffset(pagination.Page, pagination.PageSize);

        var pipeline = _followsContext
            .Follows
            .Aggregate()
            .Includes(includeProperties)
            .Match(match);

        var entities = await pipeline
            .Sort(sortOrder.Sort(sortProperty.Property))
            .Skip(offset)
            .Limit(pagination.PageSize)
            .ToListAsync(cancellationToken);

        var totalCount = await _followsContext.Follows.GetCount(match, cancellationToken);
        var collectionEntities = _followCollectionFactory.Create(entities, totalCount, pagination);

        return collectionEntities;
    }

    public async Task<Follow?> GetByIdAsync(
        FollowId id,
        CommonIncludeQuery<FollowIncludeProperty>? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _followIncludePropertyFactory.Create(include?.Properties);

        var entity = await _followsContext
            .Follows
            .Aggregate()
            .Includes(includeProperties)
            .Match(id.GetFilter())
            .FirstOrDefaultAsync(cancellationToken);

        return entity;
    }

    public async Task<Follow?> GetByIdAsync(
        FollowId id,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, null, cancellationToken);
    }

    public async Task AddAsync(Follow entity, CancellationToken cancellationToken)
    {
        await _followsContext
            .Follows
            .AddAsync(_followsContext.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<Follow> entities, CancellationToken cancellationToken)
    {
        await _followsContext
            .Follows
            .AddRangeAsync(_followsContext.ClientSessionHandle, entities, cancellationToken);
    }

    public async Task DeleteAsync(Follow entity, CancellationToken cancellationToken)
    {
        await _followsContext
            .Follows
            .DeleteAsync(
            _followsContext.ClientSessionHandle,
            entity.Id.GetFilter(),
            cancellationToken);
    }
}
