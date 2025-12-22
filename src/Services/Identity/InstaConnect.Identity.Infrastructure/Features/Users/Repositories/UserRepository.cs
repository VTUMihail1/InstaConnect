using InstaConnect.Common.Domain.Models;
using InstaConnect.Identity.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly IPaginator _paginator;
    private readonly IIdentityContext _identityContext;
    private readonly ISortOrderFactory _sortOrderFactory;
    private readonly IUserCollectionFactory _userCollectionFactory;
    private readonly IUserSortPropertyFactory _userSortPropertyFactory;
    private readonly IUserIncludePropertyFactory _userIncludePropertyFactory;

    public UserRepository(
        IPaginator paginator,
        IIdentityContext identityContext,
        ISortOrderFactory sortOrderFactory,
        IUserCollectionFactory userCollectionFactory,
        IUserSortPropertyFactory userSortPropertyFactory,
        IUserIncludePropertyFactory userIncludePropertyFactory)
    {
        _paginator = paginator;
        _identityContext = identityContext;
        _sortOrderFactory = sortOrderFactory;
        _userCollectionFactory = userCollectionFactory;
        _userSortPropertyFactory = userSortPropertyFactory;
        _userIncludePropertyFactory = userIncludePropertyFactory;
    }

    public async Task<UserCollection> GetAllAsync(
        UserFilterQuery filter,
        CommonSortingQuery<UserSortProperty> sorting,
        CommonPaginationQuery pagination,
        CommonIncludeQuery<UserIncludeProperty>? include,
        CancellationToken cancellationToken)
    {
        var match = filter.GetFilter();
        var sortOrder = _sortOrderFactory.Create(sorting.Order);
        var sortProperty = _userSortPropertyFactory.Create(sorting.Property);
        var includeProperties = _userIncludePropertyFactory.Create(include?.Properties);
        var offset = _paginator.GetOffset(pagination.Page, pagination.PageSize);

        var pipeline = _identityContext
            .Users
            .Aggregate()
            .Includes(includeProperties)
            .Match(match);

        var entities = await pipeline
            .Sort(sortOrder.Sort(sortProperty.Property))
            .Skip(offset)
            .Limit(pagination.PageSize)
            .ToListAsync(cancellationToken);

        var totalCount = await _identityContext.Users.GetCount(match, cancellationToken);
        var collectionEntities = _userCollectionFactory.Create(entities, totalCount, pagination);

        return collectionEntities;
    }

    public async Task<User?> GetByIdAsync(
        UserId id,
        CommonIncludeQuery<UserIncludeProperty>? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _userIncludePropertyFactory.Create(include?.Properties);

        var entity = await _identityContext
            .Users
            .Aggregate()
            .Includes(includeProperties)
            .Match(id.GetFilter())
            .FirstOrDefaultAsync(cancellationToken);

        return entity;
    }

    public async Task<User?> GetByIdAsync(
        UserId id,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, null, cancellationToken);
    }

    public async Task<User?> GetByNameAsync(
        Name name,
        CommonIncludeQuery<UserIncludeProperty>? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _userIncludePropertyFactory.Create(include?.Properties);

        var entity = await _identityContext
            .Users
            .Aggregate()
            .Includes(includeProperties)
            .Match(name.GetFilter())
            .FirstOrDefaultAsync(cancellationToken);

        return entity;
    }

    public async Task<User?> GetByNameAsync(
        Name name,
        CancellationToken cancellationToken)
    {
        return await GetByNameAsync(name, null, cancellationToken);
    }

    public async Task<User?> GetByEmailAsync(
        Email email,
        CommonIncludeQuery<UserIncludeProperty>? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _userIncludePropertyFactory.Create(include?.Properties);

        var entity = await _identityContext
            .Users
            .Aggregate()
            .Includes(includeProperties)
            .Match(email.GetFilter())
            .FirstOrDefaultAsync(cancellationToken);

        return entity;
    }

    public async Task<User?> GetByEmailAsync(
        Email email,
        CancellationToken cancellationToken)
    {
        return await GetByEmailAsync(email, null, cancellationToken);
    }

    public async Task AddAsync(User entity, CancellationToken cancellationToken)
    {
        await _identityContext
            .Users
            .AddAsync(_identityContext.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<User> entities, CancellationToken cancellationToken)
    {
        await _identityContext
            .Users
            .AddRangeAsync(_identityContext.ClientSessionHandle, entities, cancellationToken);
    }

    public async Task UpdateAsync(User entity, CancellationToken cancellationToken)
    {
        await _identityContext
            .Users
            .UpdateAsync(_identityContext.ClientSessionHandle, entity.Id.GetFilter(), entity, cancellationToken);
    }

    public async Task DeleteAsync(User entity, CancellationToken cancellationToken)
    {
        await _identityContext
            .Users
            .DeleteAsync(_identityContext.ClientSessionHandle, entity.Id.GetFilter(), cancellationToken);
    }
}
