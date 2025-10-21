using InstaConnect.Common.Extensions;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Domain.Features.Follows.Models.Responses;
using InstaConnect.Follows.Infrastructure.Abstractions;
using InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

using MongoDB.Driver;
using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;

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

    public async Task<FollowCollection> GetAllByFollowerIdAsync(
        FollowByFollowerFilterQuery filter,
        FollowByFollowerSortingQuery sorting,
        FollowPaginationQuery pagination,
        FollowIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var sortOrder = _sortOrderFactory.Create(sorting.Order);
        var sortProperty = _followByFollowerSortPropertyFactory.Create(sorting.Property);
        var includeProperties = _followIncludePropertyFactory.Create(include?.Properties);
        var offset = _paginator.GetOffset(pagination.Page, pagination.PageSize);
        var isFollowingNameEmpty = filter.FollowingName.IsNullOrEmptyOrWhiteSpace();

        var pipeline = _followsContext
            .Follows
            .Aggregate()
            .Includes(includeProperties)
            .Match(p =>  p.FollowerId == filter.FollowerId ||
                         isFollowingNameEmpty || p.Following!.Name.StartsWithOrdinalIgnoreCase(filter.FollowingName));

        var totalCountsResult = await pipeline.Count().FirstOrDefaultAsync(cancellationToken);

        var entities = await pipeline
            .Sort(sortOrder.Sort(sortProperty.Property))
            .Skip(offset)
            .Limit(pagination.PageSize)
            .ToListAsync(cancellationToken);

        var collectionEntities = _followCollectionFactory.Create(entities, (int)totalCountsResult.Count, pagination);

        return collectionEntities;
    }

    public async Task<FollowCollection> GetAllByFollowingIdAsync(
        FollowByFollowingFilterQuery filter,
        FollowByFollowingSortingQuery sorting,
        FollowPaginationQuery pagination,
        FollowIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var sortOrder = _sortOrderFactory.Create(sorting.Order);
        var sortProperty = _followByFollowingSortPropertyFactory.Create(sorting.Property);
        var includeProperties = _followIncludePropertyFactory.Create(include?.Properties);
        var offset = _paginator.GetOffset(pagination.Page, pagination.PageSize);
        var isFollowerNameEmpty = filter.FollowerName.IsNullOrEmptyOrWhiteSpace();

        var pipeline = _followsContext
            .Follows
            .Aggregate()
            .Includes(includeProperties)
            .Match(p => p.FollowerId == filter.FollowingId ||
                        isFollowerNameEmpty || p.Follower!.Name.StartsWithOrdinalIgnoreCase(filter.FollowerName));

        var totalCountsResult = await pipeline.Count().FirstOrDefaultAsync(cancellationToken);

        var entities = await pipeline
            .Sort(sortOrder.Sort(sortProperty.Property))
            .Skip(offset)
            .Limit(pagination.PageSize)
            .ToListAsync(cancellationToken);

        var collectionEntities = _followCollectionFactory.Create(entities, (int)totalCountsResult.Count, pagination);

        return collectionEntities;
    }

    public async Task<Follow?> GetByIdAsync(
        string followerId,
        string followingId,
        FollowIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _followIncludePropertyFactory.Create(include?.Properties);

        var entity = await _followsContext
            .Follows
            .Aggregate()
            .Includes(includeProperties)
            .Match(p => p.FollowerId == followerId && p.FollowingId == followingId)
            .FirstOrDefaultAsync(cancellationToken);

        return entity;
    }

    public async Task<Follow?> GetByIdAsync(
        string followerId,
        string followingId,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(followerId, followingId, null, cancellationToken);
    }

    public async Task AddAsync(Follow entity, CancellationToken cancellationToken)
    {
        await _followsContext
            .Follows
            .AddAsync(_followsContext.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task UpdateAsync(Follow entity, CancellationToken cancellationToken)
    {
        await _followsContext
            .Follows
            .UpdateAsync(
            _followsContext.ClientSessionHandle,
            x => x.FollowerId == entity.FollowerId && x.FollowingId == entity.FollowingId,
            entity,
            cancellationToken);
    }

    public async Task DeleteAsync(Follow entity, CancellationToken cancellationToken)
    {
        await _followsContext
            .Follows
            .DeleteAsync(
            _followsContext.ClientSessionHandle,
            x => x.FollowerId == entity.FollowerId && x.FollowingId == entity.FollowingId,
            cancellationToken);
    }
}
