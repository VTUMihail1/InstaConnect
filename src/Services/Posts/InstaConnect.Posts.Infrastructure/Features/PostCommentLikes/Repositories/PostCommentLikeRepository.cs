using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;

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
        var isUserNameEmpty = filter.UserName.IsEmpty();

        var pipeline = _postsContext
            .PostCommentLikes
            .Aggregate()
            .Includes(includeProperties)
            .Match(p => p.Id.CommentId == filter.CommentId &&
                        (isUserNameEmpty || p.User!.Name.StartsWith(filter.UserName)));

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
        PostCommentLikeId id,
        PostCommentLikeIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _postCommentLikeIncludePropertyFactory.Create(include?.Properties);

        var entity = await _postsContext
            .PostCommentLikes
            .Aggregate()
            .Includes(includeProperties)
            .Match(p => p.Id == id)
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

    public async Task DeleteAsync(PostCommentLike entity, CancellationToken cancellationToken)
    {
        await _postsContext
            .PostCommentLikes
            .DeleteAsync(
            _postsContext.ClientSessionHandle,
            p => p.Id == entity.Id,
            cancellationToken);
    }
}
