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
        FollowByFollowerSortingQuery sorting,
        FollowPaginationQuery pagination,
        FollowIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var match = Builders<Follow>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Id.FollowerId.Id, filter.FollowerId.Id)
            .AndOptionalStartsWithCaseInsensitive(p => p.Following!.Name.Value, filter.FollowingName.IsEmpty(), filter.FollowingName.Value);

        var sortOrder = _sortOrderFactory.Create(sorting.Order);
        var sortProperty = _followByFollowerSortPropertyFactory.Create(sorting.Property);
        var includeProperties = _followIncludePropertyFactory.Create(include?.Properties);
        var offset = _paginator.GetOffset(pagination.Page, pagination.PageSize);

        var pipeline = _followsContext
            .Follows
            .Aggregate()
            .Includes(includeProperties)
            .Match(match);

        var totalCountsResult = await pipeline.Count().FirstOrDefaultAsync(cancellationToken);

        var entities = await pipeline
            .Sort(sortOrder.Sort(sortProperty.Property))
            .Skip(offset)
            .Limit(pagination.PageSize)
            .ToListAsync(cancellationToken);

        var collectionEntities = _followCollectionFactory.Create(entities, (int)totalCountsResult.Count, pagination);

        return collectionEntities;
    }

    public async Task<FollowCollection> GetAllByFollowingAsync(
        FollowByFollowingFilterQuery filter,
        FollowByFollowingSortingQuery sorting,
        FollowPaginationQuery pagination,
        FollowIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var match = Builders<Follow>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Id.FollowingId.Id, filter.FollowingId.Id)
            .AndOptionalStartsWithCaseInsensitive(p => p.Follower!.Name.Value, filter.FollowerName.IsEmpty(), filter.FollowerName.Value);

        var sortOrder = _sortOrderFactory.Create(sorting.Order);
        var sortProperty = _followByFollowingSortPropertyFactory.Create(sorting.Property);
        var includeProperties = _followIncludePropertyFactory.Create(include?.Properties);
        var offset = _paginator.GetOffset(pagination.Page, pagination.PageSize);

        var pipeline = _followsContext
            .Follows
            .Aggregate()
            .Includes(includeProperties)
            .Match(match);

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
        FollowId id,
        FollowIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var match = Builders<Follow>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Id.FollowerId.Id, id.FollowerId.Id)
            .AndEqualsCaseInsensitive(p => p.Id.FollowingId.Id, id.FollowingId.Id);

        var includeProperties = _followIncludePropertyFactory.Create(include?.Properties);

        var entity = await _followsContext
            .Follows
            .Aggregate()
            .Includes(includeProperties)
            .Match(match)
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

    public async Task DeleteAsync(Follow entity, CancellationToken cancellationToken)
    {
        var match = Builders<Follow>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Id.FollowerId.Id, entity.Id.FollowerId.Id)
            .AndEqualsCaseInsensitive(p => p.Id.FollowingId.Id, entity.Id.FollowingId.Id);

        await _followsContext
            .Follows
            .DeleteAsync(
            _followsContext.ClientSessionHandle,
            match,
            cancellationToken);
    }
}
