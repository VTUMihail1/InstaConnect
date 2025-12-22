using InstaConnect.Common.Domain.Models;
using InstaConnect.Follows.Infrastructure.Features.Users.Extensions;

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
        CommonIncludeQuery<UserIncludeProperty>? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _userIncludePropertyFactory.Create(include?.Properties);

        var entity = await _followsContext
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

        var entity = await _followsContext
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

        var entity = await _followsContext
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
        await _followsContext
            .Users
            .AddAsync(_followsContext.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<User> entities, CancellationToken cancellationToken)
    {
        await _followsContext
            .Users
            .AddRangeAsync(_followsContext.ClientSessionHandle, entities, cancellationToken);
    }

    public async Task UpdateAsync(User entity, CancellationToken cancellationToken)
    {
        await _followsContext
            .Users
            .UpdateAsync(_followsContext.ClientSessionHandle, entity.Id.GetFilter(), entity, cancellationToken);
    }

    public async Task DeleteAsync(User entity, CancellationToken cancellationToken)
    {
        await _followsContext
            .Users
            .DeleteAsync(_followsContext.ClientSessionHandle, entity.Id.GetFilter(), cancellationToken);
    }
}
