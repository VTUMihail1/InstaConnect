using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Extensions;
using InstaConnect.Chats.Infrastructure.Features.Common.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Repositories;

internal class ChatMessageCommandRepository : IChatMessageCommandRepository
{
    private readonly IChatsContext _context;
    private readonly IChatMessageIncluderFactory _messageIncluderFactory;

    public ChatMessageCommandRepository(
        IChatsContext context,
        IChatMessageIncluderFactory messageIncluderFactory)
    {
        _context = context;
        _messageIncluderFactory = messageIncluderFactory;
    }

    public async Task<ChatMessage?> GetByIdAsync(
        ChatMessageId id,
        ChatMessageInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .ChatMessages
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_messageIncluderFactory, include)
            .Match(id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<ChatMessage?> GetByIdAsync(
        ChatMessageId id,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, null, cancellationToken);
    }

    public async Task<bool> ExistsByIdAsync(
        ChatMessageId id,
        CancellationToken cancellationToken)
    {
        return await _context
            .ChatMessages
            .AggregateWithCaseInsensitiveCollation()
            .Match(id)
            .AnyAsync(cancellationToken);
    }

    public async Task AddAsync(ChatMessage entity, CancellationToken cancellationToken)
    {
        await _context
            .ChatMessages
            .AddAsync(_context.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<ChatMessage> entities, CancellationToken cancellationToken)
    {
        await _context
            .ChatMessages
            .AddRangeAsync(_context.ClientSessionHandle, entities, cancellationToken);
    }

    public async Task UpdateAsync(ChatMessage entity, CancellationToken cancellationToken)
    {
        await _context
            .ChatMessages
            .UpdateAsync(_context.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task DeleteAsync(ChatMessage entity, CancellationToken cancellationToken)
    {
        await _context
            .ChatMessages
            .DeleteAsync(_context.ClientSessionHandle, entity, cancellationToken);
    }
}
