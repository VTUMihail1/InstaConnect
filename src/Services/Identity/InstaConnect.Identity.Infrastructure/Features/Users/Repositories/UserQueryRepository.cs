using InstaConnect.Identity.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Repositories;

internal class UserQueryRepository : IUserQueryRepository
{
    private readonly IPaginator _paginator;
    private readonly IIdentityContext _context;
    private readonly IUserIncluderFactory _includerFactory;
    private readonly ISortOrdererFactory _sortOrdererFactory;
    private readonly IUsersSortTermerFactory _sortTermerFactory;

    public UserQueryRepository(
        IPaginator paginator,
        IIdentityContext context,
        IUserIncluderFactory includerFactory,
        ISortOrdererFactory sortOrdererFactory,
        IUsersSortTermerFactory sortTermerFactory)
    {
        _paginator = paginator;
        _context = context;
        _includerFactory = includerFactory;
        _sortOrdererFactory = sortOrdererFactory;
        _sortTermerFactory = sortTermerFactory;
    }

    public async Task<ICollection<UserResponse>> GetAllAsync(
        UsersFilterQuery filter,
        CurrentUserQuery current,
        UsersSortingQuery sorting,
        UsersPaginationQuery pagination,
        UserInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .Users
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_includerFactory, include)
            .Match(filter)
            .ProjectToFullResponse(current)
            .Sort(_sortOrdererFactory, _sortTermerFactory, sorting)
            .Paginate(_paginator, pagination)
            .ToListAsync(cancellationToken);
    }

    public async Task<ICollection<UserResponse>> GetAllAsync(
        UsersFilterQuery filter,
        CurrentUserQuery current,
        UsersSortingQuery sorting,
        UsersPaginationQuery pagination,
        CancellationToken cancellationToken)
    {
        return await GetAllAsync(filter, current, sorting, pagination, null, cancellationToken);
    }

    public async Task<long> GetTotalCountAsync(
        UsersFilterQuery filter,
        UserInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .Users
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_includerFactory, include)
            .Match(filter)
            .GetCount(cancellationToken);
    }

    public async Task<long> GetTotalCountAsync(
        UsersFilterQuery filter,
        CancellationToken cancellationToken)
    {
        return await GetTotalCountAsync(filter, null, cancellationToken);
    }

    public async Task<UserResponse?> GetByIdAsync(
        UserId id,
        CurrentUserQuery current,
        UserInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .Users
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_includerFactory, include)
            .Match(id)
            .ProjectToFullResponse(current)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<UserResponse?> GetByIdAsync(
        UserId id,
        CurrentUserQuery current,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, current, null, cancellationToken);
    }

    public async Task<bool> ExistsByIdAsync(
        UserId id,
        CancellationToken cancellationToken)
    {
        return await _context
            .Users
            .AggregateWithCaseInsensitiveCollation()
            .Match(id)
            .AnyAsync(cancellationToken);
    }
}
