using InstaConnect.Common.Domain.Models;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Repositories;

internal class PostCommentLikeRepository : IPostCommentLikeRepository
{
    private readonly IPaginator _paginator;
    private readonly IPostsContext _postsContext;
    private readonly ISortOrderFactory _sortOrderFactory;
    private readonly IPostCommentLikeCollectionFactory _postCommentLikeCollectionFactory;
    private readonly IPostCommentLikeSortPropertyFactory _postCommentLikeSortPropertyFactory;
    private readonly IPostCommentLikeIncludePropertyFactory _postCommentLikeIncludePropertyFactory;

    public PostCommentLikeRepository(
        IPaginator paginator,
        IPostsContext postsContext,
        ISortOrderFactory sortOrderFactory,
        IPostCommentLikeCollectionFactory postCommentLikeCollectionFactory,
        IPostCommentLikeSortPropertyFactory postCommentLikeSortPropertyFactory,
        IPostCommentLikeIncludePropertyFactory postCommentLikeIncludePropertyFactory)
    {
        _paginator = paginator;
        _postsContext = postsContext;
        _sortOrderFactory = sortOrderFactory;
        _postCommentLikeCollectionFactory = postCommentLikeCollectionFactory;
        _postCommentLikeSortPropertyFactory = postCommentLikeSortPropertyFactory;
        _postCommentLikeIncludePropertyFactory = postCommentLikeIncludePropertyFactory;
    }

    public async Task<PostCommentLikeCollection> GetAllAsync(
        PostCommentLikeFilterQuery filter,
        CommonSortingQuery<PostCommentLikeSortProperty> sorting,
        CommonPaginationQuery pagination,
        CommonIncludeQuery<PostCommentLikeIncludeProperty>? include,
        CancellationToken cancellationToken)
    {
        var match = filter.GetFilter();
        var sortOrder = _sortOrderFactory.Create(sorting.Order);
        var sortProperty = _postCommentLikeSortPropertyFactory.Create(sorting.Property);
        var includeProperties = _postCommentLikeIncludePropertyFactory.Create(include?.Properties);
        var offset = _paginator.GetOffset(pagination.Page, pagination.PageSize);

        var pipeline = _postsContext
            .PostCommentLikes
            .Aggregate()
            .Includes(includeProperties)
            .Match(filter.GetFilter());
        var entities = await pipeline
            .Sort(sortOrder.Sort(sortProperty.Property))
            .Skip(offset)
            .Limit(pagination.PageSize)
            .ToListAsync(cancellationToken);

        var totalCount = await _postsContext.PostCommentLikes.GetCount(match, cancellationToken);
        var collectionEntities = _postCommentLikeCollectionFactory.Create(entities, totalCount, pagination);

        return collectionEntities;
    }

    public async Task<PostCommentLike?> GetByIdAsync(
        PostCommentLikeId id,
        CommonIncludeQuery<PostCommentLikeIncludeProperty>? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _postCommentLikeIncludePropertyFactory.Create(include?.Properties);

        var entity = await _postsContext
            .PostCommentLikes
            .Aggregate()
            .Includes(includeProperties)
            .Match(id.GetFilter())
            .FirstOrDefaultAsync(cancellationToken);

        return entity;
    }

    public async Task<PostCommentLike?> GetByIdAsync(
        PostCommentLikeId id,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, null, cancellationToken);
    }

    public async Task AddAsync(PostCommentLike entity, CancellationToken cancellationToken)
    {
        await _postsContext
            .PostCommentLikes
            .AddAsync(_postsContext.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<PostCommentLike> entities, CancellationToken cancellationToken)
    {
        await _postsContext
            .PostCommentLikes
            .AddRangeAsync(_postsContext.ClientSessionHandle, entities, cancellationToken);
    }

    public async Task DeleteAsync(PostCommentLike entity, CancellationToken cancellationToken)
    {
        await _postsContext
            .PostCommentLikes
            .DeleteAsync(
            _postsContext.ClientSessionHandle,
            entity.Id.GetFilter(),
            cancellationToken);
    }
}
