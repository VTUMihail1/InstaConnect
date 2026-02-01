using InstaConnect.Identity.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Repositories;

internal class UserQueryRepository : IUserQueryRepository
{
    private readonly IPaginator _paginator;
    private readonly IIdentityContext _context;
    private readonly ISortOrdererFactory _sortOrderFactory;
    private readonly IUserSortPropertyFactory _sortPropertyFactory;
    private readonly IUserIncludePropertyFactory _includePropertyFactory;

    public UserQueryRepository(
        IPaginator paginator,
        IIdentityContext context,
        ISortOrdererFactory sortOrderFactory,
        IUserSortPropertyFactory sortPropertyFactory,
        IUserIncludePropertyFactory includePropertyFactory)
    {
        _paginator = paginator;
        _context = context;
        _sortOrderFactory = sortOrderFactory;
        _sortPropertyFactory = sortPropertyFactory;
        _includePropertyFactory = includePropertyFactory;
    }

    public async Task<ICollection<UserResponse>> GetAllAsync(
        UserFilterQuery filter,
        CurrentUserQuery current,
        UserSortingQuery sorting,
        UserPaginationQuery pagination,
        UserInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .Users
            .Aggregate()
            .Includes(_includePropertyFactory, include)
            .Match(filter)
            .ProjectToResponse(current)
            .Sort(_sortOrderFactory, _sortPropertyFactory, sorting)
            .Paginate(_paginator, pagination)
            .ToListAsync(cancellationToken);
    }

    public async Task<ICollection<UserResponse>> GetAllAsync(
        UserFilterQuery filter,
        CurrentUserQuery current,
        UserSortingQuery sorting,
        UserPaginationQuery pagination,
        CancellationToken cancellationToken)
    {
        return await GetAllAsync(filter, current, sorting, pagination, null, cancellationToken);
    }

    public async Task<long> GetTotalCountAsync(
        UserFilterQuery filter,
        UserInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .Users
            .Aggregate()
            .Includes(_includePropertyFactory, include)
            .Match(filter)
            .GetCount(cancellationToken);
    }

    public async Task<long> GetTotalCountAsync(
        UserFilterQuery filter,
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
            .Aggregate()
            .Match(id)
            .ProjectToResponse(current)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<UserResponse?> GetByIdAsync(
        UserId id,
        CurrentUserQuery current,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, current, null, cancellationToken);
    }
}
