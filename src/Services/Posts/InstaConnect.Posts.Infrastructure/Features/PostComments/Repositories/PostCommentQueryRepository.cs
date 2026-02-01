using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Repositories;

internal class PostCommentQueryRepository : IPostCommentQueryRepository
{
    private readonly IPaginator _paginator;
    private readonly IPostsContext _context;
    private readonly ISortOrdererFactory _sortOrdererFactory;
    private readonly IPostCommentIncluderFactory _commentIncluderFactory;
    private readonly IPostCommentsSortTermerFactory _commentSortTermerFactory;

    public PostCommentQueryRepository(
        IPaginator paginator,
        IPostsContext context,
        ISortOrdererFactory sortOrdererFactory,
        IPostCommentIncluderFactory commentIncluderFactory,
        IPostCommentsSortTermerFactory commentSortTermerFactory)
    {
        _paginator = paginator;
        _context = context;
        _sortOrdererFactory = sortOrdererFactory;
        _commentIncluderFactory = commentIncluderFactory;
        _commentSortTermerFactory = commentSortTermerFactory;
    }

    public async Task<ICollection<PostCommentResponse>> GetAllAsync(
        PostCommentsFilterQuery filter,
        CurrentUserQuery currentUser,
        PostCommentsSortingQuery sorting,
        PostCommentsPaginationQuery pagination,
        PostCommentInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .PostComments
            .Aggregate()
            .Includes(_commentIncluderFactory, include)
            .Match(filter)
            .ProjectToResponse(currentUser)
            .Sort(_sortOrdererFactory, _commentSortTermerFactory, sorting)
            .Paginate(_paginator, pagination)
            .ToListAsync(cancellationToken);
    }

    public async Task<ICollection<PostCommentResponse>> GetAllAsync(
        PostCommentsFilterQuery filter,
        CurrentUserQuery currentUser,
        PostCommentsSortingQuery sorting,
        PostCommentsPaginationQuery pagination,
        CancellationToken cancellationToken)
    {
        return await GetAllAsync(filter, currentUser, sorting, pagination, null, cancellationToken);
    }

    public async Task<ICollection<PostCommentResponse>> GetAllForUserAsync(
        PostCommentsForUserFilterQuery filter,
        CurrentUserQuery currentUser,
        PostCommentsSortingQuery sorting,
        PostCommentsPaginationQuery pagination,
        PostCommentInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .PostComments
            .Aggregate()
            .Includes(_commentIncluderFactory, include)
            .Match(filter)
            .ProjectToResponse(currentUser)
            .Sort(_sortOrdererFactory, _commentSortTermerFactory, sorting)
            .Paginate(_paginator, pagination)
            .ToListAsync(cancellationToken);
    }

    public async Task<ICollection<PostCommentResponse>> GetAllForUserAsync(
        PostCommentsForUserFilterQuery filter,
        CurrentUserQuery currentUser,
        PostCommentsSortingQuery sorting,
        PostCommentsPaginationQuery pagination,
        CancellationToken cancellationToken)
    {
        return await GetAllForUserAsync(filter, currentUser, sorting, pagination, null, cancellationToken);
    }

    public async Task<long> GetTotalCountAsync(
        PostCommentsFilterQuery filter,
        PostCommentInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .PostComments
            .Aggregate()
            .Includes(_commentIncluderFactory, include)
            .Match(filter)
            .GetCount(cancellationToken);
    }

    public async Task<long> GetTotalCountAsync(
        PostCommentsFilterQuery filter,
        CancellationToken cancellationToken)
    {
        return await GetTotalCountAsync(filter, null, cancellationToken);
    }

    public async Task<long> GetTotalCountForUserAsync(
        PostCommentsForUserFilterQuery filter,
        PostCommentInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .PostComments
            .Aggregate()
            .Includes(_commentIncluderFactory, include)
            .Match(filter)
            .GetCount(cancellationToken);
    }

    public async Task<long> GetTotalCountForUserAsync(
        PostCommentsForUserFilterQuery filter,
        CancellationToken cancellationToken)
    {
        return await GetTotalCountForUserAsync(filter, null, cancellationToken);
    }

    public async Task<PostCommentResponse?> GetByIdAsync(
        PostCommentId id,
        CurrentUserQuery currentUser,
        PostCommentInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .PostComments
            .Aggregate()
            .Includes(_commentIncluderFactory, include)
            .Match(id)
            .ProjectToResponse(currentUser)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<PostCommentResponse?> GetByIdAsync(
        PostCommentId id,
        CurrentUserQuery currentUser,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, currentUser, null, cancellationToken);
    }

    public async Task<bool> ExistsByIdAsync(
        PostCommentId id,
        CancellationToken cancellationToken)
    {
        return await _context
            .PostComments
            .Aggregate()
            .Match(id)
            .AnyAsync(cancellationToken);
    }
}
