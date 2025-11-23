using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Users.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly IChatsContext _chatsContext;
    private readonly IUserIncludePropertyFactory _chatIncludePropertyFactory;

    public UserRepository(
        IChatsContext chatsContext,
        IUserIncludePropertyFactory chatIncludePropertyFactory)
    {
        _chatsContext = chatsContext;
        _chatIncludePropertyFactory = chatIncludePropertyFactory;
    }

    public async Task<User?> GetByIdAsync(
        UserId id,
        UserIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _chatIncludePropertyFactory.Create(include?.Properties);

        var entity = await _chatsContext
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
        var includeProperties = _chatIncludePropertyFactory.Create(include?.Properties);

        var entity = await _chatsContext
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
        var includeProperties = _chatIncludePropertyFactory.Create(include?.Properties);

        var entity = await _chatsContext
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
        await _chatsContext
            .Users
            .AddAsync(_chatsContext.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task UpdateAsync(User entity, CancellationToken cancellationToken)
    {
        await _chatsContext
            .Users
            .UpdateAsync(_chatsContext.ClientSessionHandle, x => x.Id == entity.Id, entity, cancellationToken);
    }

    public async Task DeleteAsync(User entity, CancellationToken cancellationToken)
    {
        await _chatsContext
            .Users
            .DeleteAsync(_chatsContext.ClientSessionHandle, x => x.Id == entity.Id, cancellationToken);
    }
}
