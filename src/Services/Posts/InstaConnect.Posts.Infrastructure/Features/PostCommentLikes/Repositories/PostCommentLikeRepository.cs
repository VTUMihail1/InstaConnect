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
        PostCommentLikeSortingQuery sorting,
        PostCommentLikePaginationQuery pagination,
        PostCommentLikeIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var sortOrder = _sortOrderFactory.Create(sorting.Order);
        var sortProperty = _postCommentLikeSortPropertyFactory.Create(sorting.Property);
        var includeProperties = _postCommentLikeIncludePropertyFactory.Create(include?.Properties);
        var offset = _paginator.GetOffset(pagination.Page, pagination.PageSize);
        var isUserNameEmpty = filter.UserName.IsNullOrEmptyOrWhiteSpace();

        var pipeline = _postsContext
            .PostCommentLikes
            .Aggregate()
            .Includes(includeProperties)
            .Match(p => p.Id == filter.Id &&
                        p.CommentId == filter.CommentId &&
                        (isUserNameEmpty || p.User!.Name.StartsWithOrdinalIgnoreCase(filter.UserName)));

        var totalCountsResult = await pipeline.Count().FirstOrDefaultAsync(cancellationToken);

        var entities = await pipeline
            .Sort(sortOrder.Sort(sortProperty.Property))
            .Skip(offset)
            .Limit(pagination.PageSize)
            .ToListAsync(cancellationToken);

        var collectionEntities = _postCommentLikeCollectionFactory.Create(entities, (int)totalCountsResult.Count, pagination);

        return collectionEntities;
    }

    public async Task<PostCommentLike?> GetByIdAsync(
        string id,
        string commentId,
        string userId,
        PostCommentLikeIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _postCommentLikeIncludePropertyFactory.Create(include?.Properties);

        var entity = await _postsContext
            .PostCommentLikes
            .Aggregate()
            .Includes(includeProperties)
            .Match(p => p.Id == id && p.CommentId == commentId && p.UserId == userId)
            .FirstOrDefaultAsync(cancellationToken);

        return entity;
    }

    public async Task<PostCommentLike?> GetByIdAsync(
        string id,
        string commentId,
        string userId,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, commentId, userId, null, cancellationToken);
    }

    public async Task AddAsync(PostCommentLike entity, CancellationToken cancellationToken)
    {
        await _postsContext
            .PostCommentLikes
            .AddAsync(_postsContext.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task UpdateAsync(PostCommentLike entity, CancellationToken cancellationToken)
    {
        await _postsContext
            .PostCommentLikes
            .UpdateAsync(
            _postsContext.ClientSessionHandle,
            p => p.Id == entity.Id && p.CommentId == entity.CommentId && p.UserId == entity.UserId,
            entity,
            cancellationToken);
    }

    public async Task DeleteAsync(PostCommentLike entity, CancellationToken cancellationToken)
    {
        await _postsContext
            .PostCommentLikes
            .DeleteAsync(
            _postsContext.ClientSessionHandle,
            p => p.Id == entity.Id && p.CommentId == entity.CommentId && p.UserId == entity.UserId,
            cancellationToken);
    }
}
