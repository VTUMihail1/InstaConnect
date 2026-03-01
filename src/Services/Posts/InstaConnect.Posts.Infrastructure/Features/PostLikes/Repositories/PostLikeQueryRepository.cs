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
    private readonly IPostLikesForUserSortTermerFactory _likeForUserSortTermerFactory;

    public PostLikeQueryRepository(
        IPaginator paginator,
        IPostsContext context,
        ISortOrdererFactory sortOrdererFactory,
        IPostLikeIncluderFactory likeIncluderFactory,
        IPostLikesSortTermerFactory likeSortTermerFactory,
        IPostLikesForUserSortTermerFactory likeForUserSortTermerFactory)
    {
        _paginator = paginator;
        _context = context;
        _sortOrdererFactory = sortOrdererFactory;
        _likeIncluderFactory = likeIncluderFactory;
        _likeSortTermerFactory = likeSortTermerFactory;
        _likeForUserSortTermerFactory = likeForUserSortTermerFactory;
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
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_likeIncluderFactory, include)
            .Match(filter)
            .ProjectToResponseWithoutPost(currentUser)
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
        PostLikesForUserSortingQuery sorting,
        PostLikesPaginationQuery pagination,
        PostLikeInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .PostLikes
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_likeIncluderFactory, include)
            .Match(filter)
            .ProjectToResponseWithoutUser(currentUser)
            .Sort(_sortOrdererFactory, _likeForUserSortTermerFactory, sorting)
            .Paginate(_paginator, pagination)
            .ToListAsync(cancellationToken);
    }

    public async Task<ICollection<PostLikeResponse>> GetAllForUserAsync(
        PostLikesForUserFilterQuery filter,
        CurrentUserQuery currentUser,
        PostLikesForUserSortingQuery sorting,
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
            .AggregateWithCaseInsensitiveCollation()
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
            .AggregateWithCaseInsensitiveCollation()
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
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_likeIncluderFactory, include)
            .Match(id)
            .ProjectToFullResponse(currentUser)
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
            .AggregateWithCaseInsensitiveCollation()
            .Match(id)
            .AnyAsync(cancellationToken);
    }
}
