using InstaConnect.Follows.Infrastructure.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure.Features.Users.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly IFollowsContext _followsContext;
    private readonly IUserIncludePropertyFactory _followIncludePropertyFactory;

    public UserRepository(
        IFollowsContext followsContext,
        IUserIncludePropertyFactory followIncludePropertyFactory)
    {
        _followsContext = followsContext;
        _followIncludePropertyFactory = followIncludePropertyFactory;
    }

    public async Task<User?> GetByIdAsync(
        string id,
        UserIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _followIncludePropertyFactory.Create(include?.Properties);

        var entity = await _followsContext
            .Users
            .Aggregate()
            .Includes(includeProperties)
            .Match(p => p.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

        return entity;
    }

    public async Task<User?> GetByIdAsync(
        string id,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, null, cancellationToken);
    }

    public async Task<User?> GetByNameAsync(
        string name,
        UserIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _followIncludePropertyFactory.Create(include?.Properties);

        var entity = await _followsContext
            .Users
            .Aggregate()
            .Includes(includeProperties)
            .Match(p => p.Name == name)
            .FirstOrDefaultAsync(cancellationToken);

        return entity;
    }

    public async Task<User?> GetByNameAsync(
        string name,
        CancellationToken cancellationToken)
    {
        return await GetByNameAsync(name, null, cancellationToken);
    }

    public async Task<User?> GetByEmailAsync(
        string email,
        UserIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _followIncludePropertyFactory.Create(include?.Properties);

        var entity = await _followsContext
            .Users
            .Aggregate()
            .Includes(includeProperties)
            .Match(p => p.Email == email)
            .FirstOrDefaultAsync(cancellationToken);

        return entity;
    }

    public async Task<User?> GetByEmailAsync(
        string email,
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
        await _followsContext
            .Users
            .UpdateAsync(_followsContext.ClientSessionHandle, x => x.Id == entity.Id, entity, cancellationToken);
    }

    public async Task DeleteAsync(User entity, CancellationToken cancellationToken)
    {
        await _followsContext
            .Users
            .DeleteAsync(_followsContext.ClientSessionHandle, x => x.Id == entity.Id, cancellationToken);
    }
}
