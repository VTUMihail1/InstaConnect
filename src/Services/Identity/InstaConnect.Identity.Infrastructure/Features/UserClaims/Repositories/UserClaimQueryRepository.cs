using InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;
using InstaConnect.Identity.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Repositories;

internal class UserClaimQueryRepository : IUserClaimQueryRepository
{
    private readonly IPaginator _paginator;
    private readonly IIdentityContext _context;
    private readonly ISortOrdererFactory _sortOrdererFactory;
    private readonly IUserClaimsSortTermerFactory _claimSortTermerFactory;

    public UserClaimQueryRepository(
        IPaginator paginator,
        IIdentityContext context,
        ISortOrdererFactory sortOrdererFactory,
        IUserClaimsSortTermerFactory claimSortTermerFactory)
    {
        _paginator = paginator;
        _context = context;
        _sortOrdererFactory = sortOrdererFactory;
        _claimSortTermerFactory = claimSortTermerFactory;
    }

    public async Task<ICollection<UserClaimResponse>> GetAllAsync(
        UserClaimsFilterQuery filter,
        CurrentUserQuery current,
        UserClaimsSortingQuery sorting,
        UserClaimsPaginationQuery pagination,
        CancellationToken cancellationToken)
    {
        return await _context
            .UserClaims
            .AggregateWithCaseInsensitiveCollation()
            .Match(filter)
            .ProjectToResponseWithoutUser(current)
            .Sort(_sortOrdererFactory, _claimSortTermerFactory, sorting)
            .Paginate(_paginator, pagination)
            .ToListAsync(cancellationToken);
    }

    public async Task<long> GetTotalCountAsync(
        UserClaimsFilterQuery filter,
        CancellationToken cancellationToken)
    {
        return await _context
            .UserClaims
            .AggregateWithCaseInsensitiveCollation()
            .Match(filter)
            .GetCount(cancellationToken);
    }

    public async Task<UserClaimResponse?> GetByIdAsync(
        UserClaimId id,
        CurrentUserQuery current,
        CancellationToken cancellationToken)
    {
        return await _context
            .UserClaims
            .AggregateWithCaseInsensitiveCollation()
            .Match(id)
            .ProjectToFullResponse(current)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<bool> ExistsByIdAsync(
        UserClaimId id,
        CancellationToken cancellationToken)
    {
        return await _context
            .UserClaims
            .AggregateWithCaseInsensitiveCollation()
            .Match(id)
            .AnyAsync(cancellationToken);
    }
}
