using InstaConnect.Common.Domain.Models.ValueObjects;
using InstaConnect.Identity.Domain.Features.Users.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Abstractions;

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
        UserSortingQuery sorting,
        UserPaginationQuery pagination,
        UserIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var sortOrder = _sortOrderFactory.Create(sorting.Order);
        var sortProperty = _userSortPropertyFactory.Create(sorting.Property);
        var includeProperties = _userIncludePropertyFactory.Create(include?.Properties);
        var offset = _paginator.GetOffset(pagination.Page, pagination.PageSize);
        var isNameEmpty = filter.Name.IsEmpty();
        var isFirstNameEmpty = filter.FirstName.IsNullOrEmptyOrWhiteSpace();
        var isLastNameEmpty = filter.LastName.IsNullOrEmptyOrWhiteSpace();

        var pipeline = _identityContext
            .Users
            .Aggregate()
            .Includes(includeProperties)
            .Match(p => isNameEmpty || p.Name.StartsWith(filter.Name) &&
                       (isFirstNameEmpty || p.FirstName.StartsWithOrdinalIgnoreCase(filter.FirstName) &&
                       (isLastNameEmpty || p.LastName.StartsWithOrdinalIgnoreCase(filter.LastName))));

        var totalCountsResult = await pipeline.Count().FirstOrDefaultAsync(cancellationToken);

        var entities = await pipeline
            .Sort(sortOrder.Sort(sortProperty.Property))
            .Skip(offset)
            .Limit(pagination.PageSize)
            .ToListAsync(cancellationToken);

        var collectionEntities = _userCollectionFactory.Create(entities, (int)totalCountsResult.Count, pagination);

        return collectionEntities;
    }

    public async Task<User?> GetByIdAsync(
        UserId id,
        UserIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _userIncludePropertyFactory.Create(include?.Properties);

        var entity = await _identityContext
            .Users
            .Aggregate()
            .Includes(includeProperties)
            .Match(p => p.Id == id)
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
        UserIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _userIncludePropertyFactory.Create(include?.Properties);

        var entity = await _identityContext
            .Users
            .Aggregate()
            .Includes(includeProperties)
            .Match(p => p.Name == name)
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
        UserIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _userIncludePropertyFactory.Create(include?.Properties);

        var entity = await _identityContext
            .Users
            .Aggregate()
            .Includes(includeProperties)
            .Match(p => p.Email == email)
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

    public async Task UpdateAsync(User entity, CancellationToken cancellationToken)
    {
        await _identityContext
            .Users
            .UpdateAsync(_identityContext.ClientSessionHandle, x => x.Id == entity.Id, entity, cancellationToken);
    }

    public async Task DeleteAsync(User entity, CancellationToken cancellationToken)
    {
        await _identityContext
            .Users
            .DeleteAsync(_identityContext.ClientSessionHandle, x => x.Id == entity.Id, cancellationToken);
    }
}
