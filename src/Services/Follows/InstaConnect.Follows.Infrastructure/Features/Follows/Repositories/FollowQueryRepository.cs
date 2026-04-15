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
    private readonly IFollowsSortTermerFactory _sortTermerFactory;
    private readonly IFollowIncludeBuilderFactory _includeBuilderFactory;
    private readonly IFollowsForFollowingSortTermerFactory _forFollowingSortTermerFactory;

    public FollowQueryRepository(
        IPaginator paginator,
        IFollowsContext context,
        IFollowIncluderFactory includerFactory,
        ISortOrdererFactory sortOrdererFactory,
        IFollowsSortTermerFactory sortTermerFactory,
        IFollowIncludeBuilderFactory includeBuilderFactory,
        IFollowsForFollowingSortTermerFactory forFollowingSortTermerFactory)
    {
        _paginator = paginator;
        _context = context;
        _includerFactory = includerFactory;
        _sortOrdererFactory = sortOrdererFactory;
        _sortTermerFactory = sortTermerFactory;
        _includeBuilderFactory = includeBuilderFactory;
        _forFollowingSortTermerFactory = forFollowingSortTermerFactory;
    }

    public async Task<ICollection<FollowResponse>> GetAllAsync(
        FollowsFilterQuery filter,
        CurrentUserQuery currentUser,
        FollowsSortingQuery sorting,
        FollowsPaginationQuery pagination,
        CancellationToken cancellationToken)
    {
        var include = _includeBuilderFactory.Create().WithFollowing().Build();

        return await _context
            .Follows
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_includerFactory, include)
            .Match(filter)
            .ProjectToResponseWithoutFollower(currentUser)
            .Sort(_sortOrdererFactory, _sortTermerFactory, sorting)
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
        var include = _includeBuilderFactory.Create().WithFollower().Build();

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

    public async Task<long> GetTotalCountAsync(
        FollowsFilterQuery filter,
        CancellationToken cancellationToken)
    {
        var include = _includeBuilderFactory.Create().WithFollowing().Build();

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
        var include = _includeBuilderFactory.Create().WithFollower().Build();

        return await _context
            .Follows
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_includerFactory, include)
            .Match(filter)
            .GetCount(cancellationToken);
    }

    public async Task<FollowResponse?> GetByIdAsync(
        FollowId id,
        CurrentUserQuery currentUser,
        CancellationToken cancellationToken)
    {
        var include = _includeBuilderFactory.Create().WithFollower().WithFollowing().Build();

        return await _context
            .Follows
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_includerFactory, include)
            .Match(id)
            .ProjectToFullResponse(currentUser)
            .FirstOrDefaultAsync(cancellationToken);
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
