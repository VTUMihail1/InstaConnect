using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Repositories;

internal class PostCommentLikeQueryRepository : IPostCommentLikeQueryRepository
{
    private readonly IPaginator _paginator;
    private readonly IPostsContext _context;
    private readonly ISortOrdererFactory _sortOrdererFactory;
    private readonly IPostCommentLikeIncluderFactory _commentLikeIncluderFactory;
    private readonly IPostCommentLikesSortTermerFactory _commentLikeSortTermerFactory;

    public PostCommentLikeQueryRepository(
        IPaginator paginator,
        IPostsContext context,
        ISortOrdererFactory sortOrdererFactory,
        IPostCommentLikeIncluderFactory commentLikeIncluderFactory,
        IPostCommentLikesSortTermerFactory commentLikeSortTermerFactory)
    {
        _paginator = paginator;
        _context = context;
        _sortOrdererFactory = sortOrdererFactory;
        _commentLikeIncluderFactory = commentLikeIncluderFactory;
        _commentLikeSortTermerFactory = commentLikeSortTermerFactory;
    }

    public async Task<ICollection<PostCommentLikeResponse>> GetAllAsync(
        PostCommentLikesFilterQuery filter,
        CurrentUserQuery currentUser,
        PostCommentLikesSortingQuery sorting,
        PostCommentLikesPaginationQuery pagination,
        PostCommentLikeInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .PostCommentLikes
            .Aggregate()
            .Includes(_commentLikeIncluderFactory, include)
            .Match(filter)
            .ProjectToResponse(currentUser)
            .Sort(_sortOrdererFactory, _commentLikeSortTermerFactory, sorting)
            .Paginate(_paginator, pagination)
            .ToListAsync(cancellationToken);
    }

    public async Task<ICollection<PostCommentLikeResponse>> GetAllAsync(
        PostCommentLikesFilterQuery filter,
        CurrentUserQuery currentUser,
        PostCommentLikesSortingQuery sorting,
        PostCommentLikesPaginationQuery pagination,
        CancellationToken cancellationToken)
    {
        return await GetAllAsync(filter, currentUser, sorting, pagination, null, cancellationToken);
    }

    public async Task<ICollection<PostCommentLikeResponse>> GetAllForUserAsync(
        PostCommentLikesForUserFilterQuery filter,
        CurrentUserQuery currentUser,
        PostCommentLikesSortingQuery sorting,
        PostCommentLikesPaginationQuery pagination,
        PostCommentLikeInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .PostCommentLikes
            .Aggregate()
            .Includes(_commentLikeIncluderFactory, include)
            .Match(filter)
            .ProjectToResponse(currentUser)
            .Sort(_sortOrdererFactory, _commentLikeSortTermerFactory, sorting)
            .Paginate(_paginator, pagination)
            .ToListAsync(cancellationToken);
    }

    public async Task<ICollection<PostCommentLikeResponse>> GetAllForUserAsync(
        PostCommentLikesForUserFilterQuery filter,
        CurrentUserQuery currentUser,
        PostCommentLikesSortingQuery sorting,
        PostCommentLikesPaginationQuery pagination,
        CancellationToken cancellationToken)
    {
        return await GetAllForUserAsync(filter, currentUser, sorting, pagination, null, cancellationToken);
    }

    public async Task<long> GetTotalCountAsync(
        PostCommentLikesFilterQuery filter,
        PostCommentLikeInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .PostCommentLikes
            .Aggregate()
            .Includes(_commentLikeIncluderFactory, include)
            .Match(filter)
            .GetCount(cancellationToken);
    }

    public async Task<long> GetTotalCountAsync(
        PostCommentLikesFilterQuery filter,
        CancellationToken cancellationToken)
    {
        return await GetTotalCountAsync(filter, null, cancellationToken);
    }

    public async Task<long> GetTotalCountForUserAsync(
        PostCommentLikesForUserFilterQuery filter,
        PostCommentLikeInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .PostCommentLikes
            .Aggregate()
            .Includes(_commentLikeIncluderFactory, include)
            .Match(filter)
            .GetCount(cancellationToken);
    }

    public async Task<long> GetTotalCountForUserAsync(
        PostCommentLikesForUserFilterQuery filter,
        CancellationToken cancellationToken)
    {
        return await GetTotalCountForUserAsync(filter, null, cancellationToken);
    }

    public async Task<PostCommentLikeResponse?> GetByIdAsync(
        PostCommentLikeId id,
        CurrentUserQuery currentUser,
        PostCommentLikeInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .PostCommentLikes
            .Aggregate()
            .Includes(_commentLikeIncluderFactory, include)
            .Match(id)
            .ProjectToResponse(currentUser)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<PostCommentLikeResponse?> GetByIdAsync(
        PostCommentLikeId id,
        CurrentUserQuery currentUser,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, currentUser, null, cancellationToken);
    }

    public async Task<bool> ExistsByIdAsync(
        PostCommentLikeId id,
        CancellationToken cancellationToken)
    {
        return await _context
            .PostCommentLikes
            .Aggregate()
            .Match(id)
            .AnyAsync(cancellationToken);
    }
}
