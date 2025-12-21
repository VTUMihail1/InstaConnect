using InstaConnect.Common.Domain.Models;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Repositories;

internal class PostLikeRepository : IPostLikeRepository
{
    private readonly IPaginator _paginator;
    private readonly IPostsContext _postsContext;
    private readonly ISortOrderFactory _sortOrderFactory;
    private readonly IPostLikeCollectionFactory _postLikeCollectionFactory;
    private readonly IPostLikeSortPropertyFactory _postLikeSortPropertyFactory;
    private readonly IPostLikeIncludePropertyFactory _postLikeIncludePropertyFactory;

    public PostLikeRepository(
        IPaginator paginator,
        IPostsContext postsContext,
        ISortOrderFactory sortOrderFactory,
        IPostLikeCollectionFactory postLikeCollectionFactory,
        IPostLikeSortPropertyFactory postLikeSortPropertyFactory,
        IPostLikeIncludePropertyFactory postLikeIncludePropertyFactory)
    {
        _paginator = paginator;
        _postsContext = postsContext;
        _sortOrderFactory = sortOrderFactory;
        _postLikeCollectionFactory = postLikeCollectionFactory;
        _postLikeSortPropertyFactory = postLikeSortPropertyFactory;
        _postLikeIncludePropertyFactory = postLikeIncludePropertyFactory;
    }

    public async Task<PostLikeCollection> GetAllAsync(
        PostLikeFilterQuery filter,
        CommonSortingQuery<PostLikeSortProperty> sorting,
        CommonPaginationQuery pagination,
        CommonIncludeQuery<PostLikeIncludeProperty>? include,
        CancellationToken cancellationToken)
    {
        var match = Builders<PostLike>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Id.Id.Id, filter.Id.Id)
            .AndOptionalStartsWithCaseInsensitive(p => p.User!.Name.Value, filter.UserName.IsEmpty(), filter.UserName.Value);

        var sortOrder = _sortOrderFactory.Create(sorting.Order);
        var sortProperty = _postLikeSortPropertyFactory.Create(sorting.Property);
        var includeProperties = _postLikeIncludePropertyFactory.Create(include?.Properties);
        var offset = _paginator.GetOffset(pagination.Page, pagination.PageSize);

        var pipeline = _postsContext
            .PostLikes
            .Aggregate()
            .Includes(includeProperties)
            .Match(match);

        var totalCount = (int)await _postsContext.PostLikes.CountDocumentsAsync(match, cancellationToken: cancellationToken);

        var entities = await pipeline
            .Sort(sortOrder.Sort(sortProperty.Property))
            .Skip(offset)
            .Limit(pagination.PageSize)
            .ToListAsync(cancellationToken);

        var collectionEntities = _postLikeCollectionFactory.Create(entities, totalCount, pagination);

        return collectionEntities;
    }

    public async Task<PostLike?> GetByIdAsync(
        PostLikeId id,
        CommonIncludeQuery<PostLikeIncludeProperty>? include,
        CancellationToken cancellationToken)
    {
        var match = Builders<PostLike>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Id.Id.Id, id.Id.Id)
            .AndEqualsCaseInsensitive(p => p.Id.UserId.Id, id.UserId.Id);

        var includeProperties = _postLikeIncludePropertyFactory.Create(include?.Properties);

        var entity = await _postsContext
            .PostLikes
            .Aggregate()
            .Includes(includeProperties)
            .Match(match)
            .FirstOrDefaultAsync(cancellationToken);

        return entity;
    }

    public async Task<PostLike?> GetByIdAsync(
        PostLikeId id,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, null, cancellationToken);
    }

    public async Task AddAsync(PostLike entity, CancellationToken cancellationToken)
    {
        await _postsContext
            .PostLikes
            .AddAsync(_postsContext.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<PostLike> entities, CancellationToken cancellationToken)
    {
        await _postsContext
            .PostLikes
            .AddRangeAsync(_postsContext.ClientSessionHandle, entities, cancellationToken);
    }

    public async Task DeleteAsync(PostLike entity, CancellationToken cancellationToken)
    {
        var match = Builders<PostLike>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Id.Id.Id, entity.Id.Id.Id)
            .AndEqualsCaseInsensitive(p => p.Id.UserId.Id, entity.Id.UserId.Id);

        await _postsContext
            .PostLikes
            .DeleteAsync(_postsContext.ClientSessionHandle, match, cancellationToken);
    }
}
