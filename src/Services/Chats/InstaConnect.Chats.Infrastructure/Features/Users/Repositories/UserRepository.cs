using InstaConnect.Chats.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Users.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly IChatsContext _chatsContext;
    private readonly IUserIncludePropertyFactory _userIncludePropertyFactory;

    public UserRepository(
        IChatsContext chatsContext,
        IUserIncludePropertyFactory userIncludePropertyFactory)
    {
        _chatsContext = chatsContext;
        _userIncludePropertyFactory = userIncludePropertyFactory;
    }

    public async Task<User?> GetByIdAsync(
        UserId id,
        CommonInclude<UserIncludeProperty>? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _userIncludePropertyFactory.Create(include?.Properties);

        var entity = await _chatsContext
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
        CommonInclude<UserIncludeProperty>? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _userIncludePropertyFactory.Create(include?.Properties);

        var entity = await _chatsContext
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
        CommonInclude<UserIncludeProperty>? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _userIncludePropertyFactory.Create(include?.Properties);

        var entity = await _chatsContext
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
        await _chatsContext
            .Users
            .AddAsync(_chatsContext.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<User> entities, CancellationToken cancellationToken)
    {
        await _chatsContext
            .Users
            .AddRangeAsync(_chatsContext.ClientSessionHandle, entities, cancellationToken);
    }

    public async Task UpdateAsync(User entity, CancellationToken cancellationToken)
    {
        await _chatsContext
            .Users
            .UpdateAsync(_chatsContext.ClientSessionHandle, entity.Id.GetFilter(), entity, cancellationToken);
    }

    public async Task DeleteAsync(User entity, CancellationToken cancellationToken)
    {
        await _chatsContext
            .Users
            .DeleteAsync(_chatsContext.ClientSessionHandle, entity.Id.GetFilter(), cancellationToken);
    }
}
