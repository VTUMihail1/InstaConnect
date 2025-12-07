using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure.Features.Users.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly IFollowsContext _followsContext;
    private readonly IUserIncludePropertyFactory _userIncludePropertyFactory;

    public UserRepository(
        IFollowsContext followsContext,
        IUserIncludePropertyFactory userIncludePropertyFactory)
    {
        _followsContext = followsContext;
        _userIncludePropertyFactory = userIncludePropertyFactory;
    }

    public async Task<User?> GetByIdAsync(
        UserId id,
        UserIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var match = Builders<User>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Id.Id, id.Id);

        var includeProperties = _userIncludePropertyFactory.Create(include?.Properties);

        var entity = await _followsContext
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

        var entity = await _followsContext
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

        var entity = await _followsContext
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
        await _followsContext
            .Users
            .AddAsync(_followsContext.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task UpdateAsync(User entity, CancellationToken cancellationToken)
    {
        var match = Builders<User>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Id.Id, entity.Id.Id);

        await _followsContext
            .Users
            .UpdateAsync(_followsContext.ClientSessionHandle, match, entity, cancellationToken);
    }

    public async Task DeleteAsync(User entity, CancellationToken cancellationToken)
    {
        var match = Builders<User>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Id.Id, entity.Id.Id);

        await _followsContext
            .Users
            .DeleteAsync(_followsContext.ClientSessionHandle, match, cancellationToken);
    }
}
