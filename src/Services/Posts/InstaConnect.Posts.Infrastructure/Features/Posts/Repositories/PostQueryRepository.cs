using InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Repositories;

internal class PostQueryRepository : IPostQueryRepository
{
    private readonly IPaginator _paginator;
    private readonly IPostsContext _context;
    private readonly IPostIncluderFactory _includerFactory;
    private readonly ISortOrdererFactory _sortOrdererFactory;
    private readonly IPostsSortTermerFactory _sortTermerFactory;
    private readonly IPostsForUserSortTermerFactory _forUserSortTermerFactory;

    public PostQueryRepository(
        IPaginator paginator,
        IPostsContext context,
        IPostIncluderFactory includerFactory,
        ISortOrdererFactory sortOrdererFactory,
        IPostsSortTermerFactory sortTermerFactory,
        IPostsForUserSortTermerFactory forUserSortTermerFactory)
    {
        _paginator = paginator;
        _context = context;
        _includerFactory = includerFactory;
        _sortOrdererFactory = sortOrdererFactory;
        _sortTermerFactory = sortTermerFactory;
        _forUserSortTermerFactory = forUserSortTermerFactory;
    }

    public async Task<ICollection<PostResponse>> GetAllAsync(
        PostsFilterQuery filter,
        CurrentUserQuery currentUser,
        PostsSortingQuery sorting,
        PostsPaginationQuery pagination,
        PostInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .Posts
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_includerFactory, include)
            .Match(filter)
            .ProjectToFullResponse(currentUser)
            .Sort(_sortOrdererFactory, _sortTermerFactory, sorting)
            .Paginate(_paginator, pagination)
            .ToListAsync(cancellationToken);
    }

    public async Task<ICollection<PostResponse>> GetAllAsync(
        PostsFilterQuery filter,
        CurrentUserQuery currentUser,
        PostsSortingQuery sorting,
        PostsPaginationQuery pagination,
        CancellationToken cancellationToken)
    {
        return await GetAllAsync(filter, currentUser, sorting, pagination, null, cancellationToken);
    }

    public async Task<ICollection<PostResponse>> GetAllForUserAsync(
        PostsForUserFilterQuery filter,
        CurrentUserQuery currentUser,
        PostsForUserSortingQuery sorting,
        PostsPaginationQuery pagination,
        PostInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .Posts
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_includerFactory, include)
            .Match(filter)
            .ProjectToResponseWithoutUser(currentUser)
            .Sort(_sortOrdererFactory, _forUserSortTermerFactory, sorting)
            .Paginate(_paginator, pagination)
            .ToListAsync(cancellationToken);
    }

    public async Task<ICollection<PostResponse>> GetAllForUserAsync(
        PostsForUserFilterQuery filter,
        CurrentUserQuery currentUser,
        PostsForUserSortingQuery sorting,
        PostsPaginationQuery pagination,
        CancellationToken cancellationToken)
    {
        return await GetAllForUserAsync(filter, currentUser, sorting, pagination, null, cancellationToken);
    }

    public async Task<long> GetTotalCountAsync(
        PostsFilterQuery filter,
        PostInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .Posts
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_includerFactory, include)
            .Match(filter)
            .GetCount(cancellationToken);
    }

    public async Task<long> GetTotalCountAsync(
        PostsFilterQuery filter,
        CancellationToken cancellationToken)
    {
        return await GetTotalCountAsync(filter, null, cancellationToken);
    }

    public async Task<long> GetTotalCountForUserAsync(
        PostsForUserFilterQuery filter,
        PostInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .Posts
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_includerFactory, include)
            .Match(filter)
            .GetCount(cancellationToken);
    }

    public async Task<long> GetTotalCountForUserAsync(
        PostsForUserFilterQuery filter,
        CancellationToken cancellationToken)
    {
        return await GetTotalCountForUserAsync(filter, null, cancellationToken);
    }

    public async Task<PostResponse?> GetByIdAsync(
        PostId id,
        CurrentUserQuery currentUser,
        PostInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .Posts
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_includerFactory, include)
            .Match(id)
            .ProjectToFullResponse(currentUser)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<PostResponse?> GetByIdAsync(
        PostId id,
        CurrentUserQuery currentUser,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, currentUser, null, cancellationToken);
    }

    public async Task<bool> ExistsByIdAsync(
        PostId id,
        CancellationToken cancellationToken)
    {
        return await _context
            .Posts
            .AggregateWithCaseInsensitiveCollation()
            .Match(id)
            .AnyAsync(cancellationToken);
    }
}
