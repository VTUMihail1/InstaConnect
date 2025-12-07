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
        var match = Builders<User>.Filter.Empty
            .AndOptionalStartsWithCaseInsensitive(p => p.Name.Value, filter.Name.IsEmpty(), filter.Name.Value)
            .AndOptionalStartsWithCaseInsensitive(p => p.FirstName, filter.FirstName.IsNullOrEmptyOrWhiteSpace(), filter.FirstName)
            .AndOptionalStartsWithCaseInsensitive(p => p.LastName, filter.LastName.IsNullOrEmptyOrWhiteSpace(), filter.LastName);

        var sortOrder = _sortOrderFactory.Create(sorting.Order);
        var sortProperty = _userSortPropertyFactory.Create(sorting.Property);
        var includeProperties = _userIncludePropertyFactory.Create(include?.Properties);
        var offset = _paginator.GetOffset(pagination.Page, pagination.PageSize);

        var pipeline = _identityContext
            .Users
            .Aggregate()
            .Includes(includeProperties)
            .Match(match);

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
        var match = Builders<User>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Id.Id, id.Id);

        var includeProperties = _userIncludePropertyFactory.Create(include?.Properties);

        var entity = await _identityContext
            .Users
            .Aggregate()
            .Includes(includeProperties)
            .Match(match)
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
        var match = Builders<User>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Name.Value, name.Value);

        var includeProperties = _userIncludePropertyFactory.Create(include?.Properties);

        var entity = await _identityContext
            .Users
            .Aggregate()
            .Includes(includeProperties)
            .Match(match)
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
        var match = Builders<User>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Email.Value, email.Value);

        var includeProperties = _userIncludePropertyFactory.Create(include?.Properties);

        var entity = await _identityContext
            .Users
            .Aggregate()
            .Includes(includeProperties)
            .Match(match)
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
        var match = Builders<User>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Id.Id, entity.Id.Id);

        await _identityContext
            .Users
            .UpdateAsync(_identityContext.ClientSessionHandle, match, entity, cancellationToken);
    }

    public async Task DeleteAsync(User entity, CancellationToken cancellationToken)
    {
        var match = Builders<User>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Id.Id, entity.Id.Id);

        await _identityContext
            .Users
            .DeleteAsync(_identityContext.ClientSessionHandle, match, cancellationToken);
    }
}
