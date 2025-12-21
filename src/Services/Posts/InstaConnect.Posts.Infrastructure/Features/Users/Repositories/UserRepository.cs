using InstaConnect.Common.Domain.Models;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly IPostsContext _postsContext;
    private readonly IUserIncludePropertyFactory _userIncludePropertyFactory;

    public UserRepository(
        IPostsContext postsContext,
        IUserIncludePropertyFactory userIncludePropertyFactory)
    {
        _postsContext = postsContext;
        _userIncludePropertyFactory = userIncludePropertyFactory;
    }

    public async Task<User?> GetByIdAsync(
        UserId id,
        CommonIncludeQuery<UserIncludeProperty>? include,
        CancellationToken cancellationToken)
    {
        var match = Builders<User>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Id.Id, id.Id);

        var includeProperties = _userIncludePropertyFactory.Create(include?.Properties);

        var entity = await _postsContext
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
        CommonIncludeQuery<UserIncludeProperty>? include,
        CancellationToken cancellationToken)
    {
        var match = Builders<User>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Name.Value, name.Value);

        var includeProperties = _userIncludePropertyFactory.Create(include?.Properties);

        var entity = await _postsContext
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
        CommonIncludeQuery<UserIncludeProperty>? include,
        CancellationToken cancellationToken)
    {
        var match = Builders<User>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Email.Value, email.Value);

        var includeProperties = _userIncludePropertyFactory.Create(include?.Properties);

        var entity = await _postsContext
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
        await _postsContext
            .Users
            .AddAsync(_postsContext.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<User> entities, CancellationToken cancellationToken)
    {
        await _postsContext
            .Users
            .AddRangeAsync(_postsContext.ClientSessionHandle, entities, cancellationToken);
    }

    public async Task UpdateAsync(User entity, CancellationToken cancellationToken)
    {
        var match = Builders<User>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Id.Id, entity.Id.Id);

        await _postsContext
            .Users
            .UpdateAsync(_postsContext.ClientSessionHandle, match, entity, cancellationToken);
    }

    public async Task DeleteAsync(User entity, CancellationToken cancellationToken)
    {
        var match = Builders<User>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Id.Id, entity.Id.Id);

        await _postsContext
            .Users
            .DeleteAsync(_postsContext.ClientSessionHandle, match, cancellationToken);
    }
}
