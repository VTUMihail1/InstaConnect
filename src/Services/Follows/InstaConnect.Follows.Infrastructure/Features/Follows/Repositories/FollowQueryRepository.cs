using InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;
using InstaConnect.Follows.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Repositories;

internal class FollowQueryRepository : IFollowQueryRepository
{
    private readonly IPaginator _paginator;
    private readonly IFollowsContext _context;
    private readonly IFollowIncluderFactory _includerFactory;
    private readonly ISortOrdererFactory _sortOrdererFactory;
    private readonly IFollowsForFollowerSortTermerFactory _forFollowerSortTermerFactory;
    private readonly IFollowsForFollowingSortTermerFactory _forFollowingSortTermerFactory;

    public FollowQueryRepository(
        IPaginator paginator,
        IFollowsContext context,
        IFollowIncluderFactory includerFactory,
        ISortOrdererFactory sortOrdererFactory,
        IFollowsForFollowerSortTermerFactory forFollowerSortTermerFactory,
        IFollowsForFollowingSortTermerFactory forFollowingSortTermerFactory)
    {
        _paginator = paginator;
        _context = context;
        _includerFactory = includerFactory;
        _sortOrdererFactory = sortOrdererFactory;
        _forFollowerSortTermerFactory = forFollowerSortTermerFactory;
        _forFollowingSortTermerFactory = forFollowingSortTermerFactory;
    }

    public async Task<ICollection<FollowResponse>> GetAllForFollowerAsync(
        FollowsForFollowerFilterQuery filter,
        CurrentUserQuery currentUser,
        FollowsForFollowerSortingQuery sorting,
        FollowsPaginationQuery pagination,
        FollowInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .Follows
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_includerFactory, include)
            .Match(filter)
            .ProjectToResponseWithoutFollower(currentUser)
            .Sort(_sortOrdererFactory, _forFollowerSortTermerFactory, sorting)
            .Paginate(_paginator, pagination)
            .ToListAsync(cancellationToken);
    }

    public async Task<ICollection<FollowResponse>> GetAllForFollowerAsync(
        FollowsForFollowerFilterQuery filter,
        CurrentUserQuery currentUser,
        FollowsForFollowerSortingQuery sorting,
        FollowsPaginationQuery pagination,
        CancellationToken cancellationToken)
    {
        return await GetAllForFollowerAsync(filter, currentUser, sorting, pagination, null, cancellationToken);
    }

    public async Task<ICollection<FollowResponse>> GetAllForFollowingAsync(
        FollowsForFollowingFilterQuery filter,
        CurrentUserQuery currentUser,
        FollowsForFollowingSortingQuery sorting,
        FollowsPaginationQuery pagination,
        FollowInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .Follows
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_includerFactory, include)
            .Match(filter)
            .ProjectToResponseWithoutFollowing(currentUser)
            .Sort(_sortOrdererFactory, _forFollowingSortTermerFactory, sorting)
            .Paginate(_paginator, pagination)
            .ToListAsync(cancellationToken);
    }

    public async Task<ICollection<FollowResponse>> GetAllForFollowingAsync(
        FollowsForFollowingFilterQuery filter,
        CurrentUserQuery currentUser,
        FollowsForFollowingSortingQuery sorting,
        FollowsPaginationQuery pagination,
        CancellationToken cancellationToken)
    {
        return await GetAllForFollowingAsync(filter, currentUser, sorting, pagination, null, cancellationToken);
    }

    public async Task<long> GetTotalCountForFollowerAsync(
        FollowsForFollowerFilterQuery filter,
        FollowInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .Follows
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_includerFactory, include)
            .Match(filter)
            .GetCount(cancellationToken);
    }

    public async Task<long> GetTotalCountForFollowerAsync(
        FollowsForFollowerFilterQuery filter,
        CancellationToken cancellationToken)
    {
        return await GetTotalCountForFollowerAsync(filter, null, cancellationToken);
    }

    public async Task<long> GetTotalCountForFollowingAsync(
        FollowsForFollowingFilterQuery filter,
        FollowInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .Follows
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_includerFactory, include)
            .Match(filter)
            .GetCount(cancellationToken);
    }

    public async Task<long> GetTotalCountForFollowingAsync(
        FollowsForFollowingFilterQuery filter,
        CancellationToken cancellationToken)
    {
        return await GetTotalCountForFollowingAsync(filter, null, cancellationToken);
    }

    public async Task<FollowResponse?> GetByIdAsync(
        FollowId id,
        CurrentUserQuery currentUser,
        FollowInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .Follows
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_includerFactory, include)
            .Match(id)
            .ProjectToFullResponse(currentUser)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<FollowResponse?> GetByIdAsync(
        FollowId id,
        CurrentUserQuery currentUser,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, currentUser, null, cancellationToken);
    }

    public async Task<bool> ExistsByIdAsync(
        FollowId id,
        CancellationToken cancellationToken)
    {
        return await _context
            .Follows
            .AggregateWithCaseInsensitiveCollation()
            .Match(id)
            .AnyAsync(cancellationToken);
    }
}
