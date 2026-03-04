using InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;
using InstaConnect.Chats.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Repositories;

internal class ChatCommandRepository : IChatCommandRepository
{
    private readonly IChatsContext _context;
    private readonly IChatIncluderFactory _includerFactory;

    public ChatCommandRepository(
        IChatsContext context,
        IChatIncluderFactory includerFactory)
    {
        _context = context;
        _includerFactory = includerFactory;
    }

    public async Task<Chat?> GetByIdAsync(
        ChatId id,
        ChatInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .Chats
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_includerFactory, include)
            .Match(id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<Chat?> GetByIdAsync(
        ChatId id,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, null, cancellationToken);
    }

    public async Task<bool> ExistsByIdAsync(
        ChatId id,
        CancellationToken cancellationToken)
    {
        return await _context
            .Chats
            .AggregateWithCaseInsensitiveCollation()
            .Match(id)
            .AnyAsync(cancellationToken);
    }

    public async Task AddAsync(Chat entity, CancellationToken cancellationToken)
    {
        await _context
            .Chats
            .AddAsync(_context.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<Chat> entities, CancellationToken cancellationToken)
    {
        await _context
            .Chats
            .AddRangeAsync(_context.ClientSessionHandle, entities, cancellationToken);
    }

    public async Task DeleteAsync(Chat entity, CancellationToken cancellationToken)
    {
        await _context
            .Chats
            .DeleteAsync(_context.ClientSessionHandle, entity, cancellationToken);
    }
}
