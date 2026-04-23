using InstaConnect.Identity.Infrastructure.Features.Common.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Repositories;

internal class UserQueryRepository : IUserQueryRepository
{
    private readonly IPaginator _paginator;
    private readonly IIdentityContext _context;
    private readonly ISortOrdererFactory _sortOrdererFactory;
    private readonly IUsersSortTermerFactory _sortTermerFactory;

    public UserQueryRepository(
        IPaginator paginator,
        IIdentityContext context,
        ISortOrdererFactory sortOrdererFactory,
        IUsersSortTermerFactory sortTermerFactory)
    {
        _paginator = paginator;
        _context = context;
        _sortOrdererFactory = sortOrdererFactory;
        _sortTermerFactory = sortTermerFactory;
    }

    public async Task<ICollection<UserResponse>> GetAllAsync(
        UsersFilterQuery filter,
        CurrentUserQuery current,
        UsersSortingQuery sorting,
        UsersPaginationQuery pagination,
        CancellationToken cancellationToken)
    {
        return await _context
            .Users
            .AggregateWithCaseInsensitiveCollation()
            .Match(filter)
            .ProjectToFullResponse(current)
            .Sort(_sortOrdererFactory, _sortTermerFactory, sorting)
            .Paginate(_paginator, pagination)
            .ToListAsync(cancellationToken);
    }

    public async Task<long> GetTotalCountAsync(
        UsersFilterQuery filter,
        CancellationToken cancellationToken)
    {
        return await _context
            .Users
            .AggregateWithCaseInsensitiveCollation()
            .Match(filter)
            .GetCount(cancellationToken);
    }

    public async Task<UserResponse?> GetByIdAsync(
        UserId id,
        CurrentUserQuery current,
        CancellationToken cancellationToken)
    {
        return await _context
            .Users
            .AggregateWithCaseInsensitiveCollation()
            .Match(id)
            .ProjectToFullResponse(current)
            .FirstOrDefaultAsync(cancellationToken);
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
