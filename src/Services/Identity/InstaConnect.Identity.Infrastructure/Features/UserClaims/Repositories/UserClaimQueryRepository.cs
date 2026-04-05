using InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;
using InstaConnect.Identity.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Repositories;

internal class UserClaimQueryRepository : IUserClaimQueryRepository
{
    private readonly IPaginator _paginator;
    private readonly IIdentityContext _context;
    private readonly ISortOrdererFactory _sortOrdererFactory;
    private readonly IUserClaimIncluderFactory _claimIncluderFactory;
    private readonly IUserClaimsSortTermerFactory _claimSortTermerFactory;

    public UserClaimQueryRepository(
        IPaginator paginator,
        IIdentityContext context,
        ISortOrdererFactory sortOrdererFactory,
        IUserClaimIncluderFactory claimIncluderFactory,
        IUserClaimsSortTermerFactory claimSortTermerFactory)
    {
        _paginator = paginator;
        _context = context;
        _sortOrdererFactory = sortOrdererFactory;
        _claimIncluderFactory = claimIncluderFactory;
        _claimSortTermerFactory = claimSortTermerFactory;
    }

    public async Task<ICollection<UserClaimResponse>> GetAllAsync(
        UserClaimsFilterQuery filter,
        CurrentUserQuery current,
        UserClaimsSortingQuery sorting,
        UserClaimsPaginationQuery pagination,
        UserClaimInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .UserClaims
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_claimIncluderFactory, include)
            .Match(filter)
            .ProjectToResponseWithoutUser(current)
            .Sort(_sortOrdererFactory, _claimSortTermerFactory, sorting)
            .Paginate(_paginator, pagination)
            .ToListAsync(cancellationToken);
    }

    public async Task<ICollection<UserClaimResponse>> GetAllAsync(
        UserClaimsFilterQuery filter,
        CurrentUserQuery current,
        UserClaimsSortingQuery sorting,
        UserClaimsPaginationQuery pagination,
        CancellationToken cancellationToken)
    {
        return await GetAllAsync(filter, current, sorting, pagination, null, cancellationToken);
    }

    public async Task<long> GetTotalCountAsync(
        UserClaimsFilterQuery filter,
        UserClaimInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .UserClaims
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_claimIncluderFactory, include)
            .Match(filter)
            .GetCount(cancellationToken);
    }

    public async Task<long> GetTotalCountAsync(
        UserClaimsFilterQuery filter,
        CancellationToken cancellationToken)
    {
        return await GetTotalCountAsync(filter, null, cancellationToken);
    }

    public async Task<UserClaimResponse?> GetByIdAsync(
        UserClaimId id,
        CurrentUserQuery current,
        UserClaimInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .UserClaims
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_claimIncluderFactory, include)
            .Match(id)
            .ProjectToFullResponse(current)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<UserClaimResponse?> GetByIdAsync(
        UserClaimId id,
        CurrentUserQuery current,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, current, null, cancellationToken);
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
