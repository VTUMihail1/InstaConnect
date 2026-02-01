using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Repositories;

internal class PostLikeQueryRepository : IPostLikeQueryRepository
{
    private readonly IPaginator _paginator;
    private readonly IPostsContext _context;
    private readonly ISortOrdererFactory _sortOrdererFactory;
    private readonly IPostLikeIncluderFactory _likeIncluderFactory;
    private readonly IPostLikesSortTermerFactory _likeSortTermerFactory;

    public PostLikeQueryRepository(
        IPaginator paginator,
        IPostsContext context,
        ISortOrdererFactory sortOrdererFactory,
        IPostLikeIncluderFactory likeIncluderFactory,
        IPostLikesSortTermerFactory likeSortTermerFactory)
    {
        _paginator = paginator;
        _context = context;
        _sortOrdererFactory = sortOrdererFactory;
        _likeIncluderFactory = likeIncluderFactory;
        _likeSortTermerFactory = likeSortTermerFactory;
    }

    public async Task<ICollection<PostLikeResponse>> GetAllAsync(
        PostLikesFilterQuery filter,
        CurrentUserQuery currentUser,
        PostLikesSortingQuery sorting,
        PostLikesPaginationQuery pagination,
        PostLikeInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .PostLikes
            .Aggregate()
            .Includes(_likeIncluderFactory, include)
            .Match(filter)
            .ProjectToResponse(currentUser)
            .Sort(_sortOrdererFactory, _likeSortTermerFactory, sorting)
            .Paginate(_paginator, pagination)
            .ToListAsync(cancellationToken);
    }

    public async Task<ICollection<PostLikeResponse>> GetAllAsync(
        PostLikesFilterQuery filter,
        CurrentUserQuery currentUser,
        PostLikesSortingQuery sorting,
        PostLikesPaginationQuery pagination,
        CancellationToken cancellationToken)
    {
        return await GetAllAsync(filter, currentUser, sorting, pagination, null, cancellationToken);
    }

    public async Task<ICollection<PostLikeResponse>> GetAllForUserAsync(
        PostLikesForUserFilterQuery filter,
        CurrentUserQuery currentUser,
        PostLikesSortingQuery sorting,
        PostLikesPaginationQuery pagination,
        PostLikeInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .PostLikes
            .Aggregate()
            .Includes(_likeIncluderFactory, include)
            .Match(filter)
            .ProjectToResponse(currentUser)
            .Sort(_sortOrdererFactory, _likeSortTermerFactory, sorting)
            .Paginate(_paginator, pagination)
            .ToListAsync(cancellationToken);
    }

    public async Task<ICollection<PostLikeResponse>> GetAllForUserAsync(
        PostLikesForUserFilterQuery filter,
        CurrentUserQuery currentUser,
        PostLikesSortingQuery sorting,
        PostLikesPaginationQuery pagination,
        CancellationToken cancellationToken)
    {
        return await GetAllForUserAsync(filter, currentUser, sorting, pagination, null, cancellationToken);
    }

    public async Task<long> GetTotalCountAsync(
        PostLikesFilterQuery filter,
        PostLikeInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .PostLikes
            .Aggregate()
            .Includes(_likeIncluderFactory, include)
            .Match(filter)
            .GetCount(cancellationToken);
    }

    public async Task<long> GetTotalCountAsync(
        PostLikesFilterQuery filter,
        CancellationToken cancellationToken)
    {
        return await GetTotalCountAsync(filter, null, cancellationToken);
    }

    public async Task<long> GetTotalCountForUserAsync(
        PostLikesForUserFilterQuery filter,
        PostLikeInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .PostLikes
            .Aggregate()
            .Includes(_likeIncluderFactory, include)
            .Match(filter)
            .GetCount(cancellationToken);
    }

    public async Task<long> GetTotalCountForUserAsync(
        PostLikesForUserFilterQuery filter,
        CancellationToken cancellationToken)
    {
        return await GetTotalCountForUserAsync(filter, null, cancellationToken);
    }

    public async Task<PostLikeResponse?> GetByIdAsync(
        PostLikeId id,
        CurrentUserQuery currentUser,
        PostLikeInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .PostLikes
            .Aggregate()
            .Includes(_likeIncluderFactory, include)
            .Match(id)
            .ProjectToResponse(currentUser)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<PostLikeResponse?> GetByIdAsync(
        PostLikeId id,
        CurrentUserQuery currentUser,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, currentUser, null, cancellationToken);
    }

    public async Task<bool> ExistsByIdAsync(
        PostLikeId id,
        CancellationToken cancellationToken)
    {
        return await _context
            .PostLikes
            .Aggregate()
            .Match(id)
            .AnyAsync(cancellationToken);
    }
}
