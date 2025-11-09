using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly IPostsContext _postsContext;
    private readonly IUserIncludePropertyFactory _postIncludePropertyFactory;

    public UserRepository(
        IPostsContext postsContext,
        IUserIncludePropertyFactory postIncludePropertyFactory)
    {
        _postsContext = postsContext;
        _postIncludePropertyFactory = postIncludePropertyFactory;
    }

    public async Task<User?> GetByIdAsync(
        string id,
        UserIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _postIncludePropertyFactory.Create(include?.Properties);

        var entity = await _postsContext
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
        var includeProperties = _postIncludePropertyFactory.Create(include?.Properties);

        var entity = await _postsContext
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
        var includeProperties = _postIncludePropertyFactory.Create(include?.Properties);

        var entity = await _postsContext
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
        await _postsContext
            .Users
            .AddAsync(_postsContext.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task UpdateAsync(User entity, CancellationToken cancellationToken)
    {
        await _postsContext
            .Users
            .UpdateAsync(_postsContext.ClientSessionHandle, x => x.Id == entity.Id, entity, cancellationToken);
    }

    public async Task DeleteAsync(User entity, CancellationToken cancellationToken)
    {
        await _postsContext
            .Users
            .DeleteAsync(_postsContext.ClientSessionHandle, x => x.Id == entity.Id, cancellationToken);
    }
}
