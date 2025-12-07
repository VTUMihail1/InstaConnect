using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Repositories;

internal class PostRepository : IPostRepository
{
    private readonly IPaginator _paginator;
    private readonly IPostsContext _postsContext;
    private readonly ISortOrderFactory _sortOrderFactory;
    private readonly IPostCollectionFactory _postCollectionFactory;
    private readonly IPostSortPropertyFactory _postSortPropertyFactory;
    private readonly IPostIncludePropertyFactory _postIncludePropertyFactory;

    public PostRepository(
        IPaginator paginator,
        IPostsContext postsContext,
        ISortOrderFactory sortOrderFactory,
        IPostCollectionFactory postCollectionFactory,
        IPostSortPropertyFactory postSortPropertyFactory,
        IPostIncludePropertyFactory postIncludePropertyFactory)
    {
        _paginator = paginator;
        _postsContext = postsContext;
        _sortOrderFactory = sortOrderFactory;
        _postCollectionFactory = postCollectionFactory;
        _postSortPropertyFactory = postSortPropertyFactory;
        _postIncludePropertyFactory = postIncludePropertyFactory;
    }

    public async Task<PostCollection> GetAllAsync(
        PostFilterQuery filter,
        PostSortingQuery sorting,
        PostPaginationQuery pagination,
        PostIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var match = Builders<Post>.Filter.Empty
            .AndOptionalEqualsCaseInsensitive(p => p.UserId.Id, filter.UserId.IsEmpty(), filter.UserId.Id)
            .AndOptionalStartsWithCaseInsensitive(p => p.User!.Name.Value, filter.UserName.IsEmpty(), filter.UserName.Value)
            .AndOptionalStartsWithCaseInsensitive(p => p.Title, filter.Title.IsNullOrEmptyOrWhiteSpace(), filter.Title);

        var sortOrder = _sortOrderFactory.Create(sorting.Order);
        var sortProperty = _postSortPropertyFactory.Create(sorting.Property);
        var includeProperties = _postIncludePropertyFactory.Create(include?.Properties);
        var offset = _paginator.GetOffset(pagination.Page, pagination.PageSize);

        var pipeline = _postsContext
            .Posts
            .Aggregate()
            .Includes(includeProperties)
            .Match(match);

        var totalCountsResult = await pipeline.Count().FirstOrDefaultAsync(cancellationToken);

        var entities = await pipeline
            .Sort(sortOrder.Sort(sortProperty.Property))
            .Skip(offset)
            .Limit(pagination.PageSize)
            .ToListAsync(cancellationToken);

        var collectionEntities = _postCollectionFactory.Create(entities, (int)totalCountsResult.Count, pagination);

        return collectionEntities;
    }

    public async Task<Post?> GetByIdAsync(
        PostId id,
        PostIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var match = Builders<Post>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Id.Id, id.Id);

        var includeProperties = _postIncludePropertyFactory.Create(include?.Properties);

        var entity = await _postsContext
            .Posts
            .Aggregate()
            .Includes(includeProperties)
            .Match(match)
            .FirstOrDefaultAsync(cancellationToken);

        return entity;
    }

    public async Task<Post?> GetByIdAsync(
        PostId id,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, null, cancellationToken);
    }

    public async Task AddAsync(Post entity, CancellationToken cancellationToken)
    {
        await _postsContext
            .Posts
            .AddAsync(_postsContext.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task UpdateAsync(Post entity, CancellationToken cancellationToken)
    {
        var match = Builders<Post>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Id.Id, entity.Id.Id);

        await _postsContext
            .Posts
            .UpdateAsync(_postsContext.ClientSessionHandle, match, entity, cancellationToken);
    }

    public async Task DeleteAsync(Post entity, CancellationToken cancellationToken)
    {
        var match = Builders<Post>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Id.Id, entity.Id.Id);

        await _postsContext
            .Posts
            .DeleteAsync(_postsContext.ClientSessionHandle, match, cancellationToken);
    }
}
