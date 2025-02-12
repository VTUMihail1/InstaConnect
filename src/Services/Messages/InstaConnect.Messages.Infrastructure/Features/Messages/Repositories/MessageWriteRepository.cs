using InstaConnect.Messages.Domain.Features.Messages.Abstractions;
using InstaConnect.Messages.Domain.Features.Messages.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Messages.Infrastructure.Features.Messages.Repositories;

internal class MessageWriteRepository : IMessageWriteRepository
{
    private readonly MessagesContext _messagesContext;

    public MessageWriteRepository(MessagesContext messagesContext)
    {
        _messagesContext = messagesContext;
    }

    public async Task<Message?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var message = await _messagesContext
            .Messages
            .Include(f => f.Sender)
            .Include(f => f.Receiver)
            .AsSplitQuery()
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return message;
    }

    public async Task<bool> AnyAsync(CancellationToken cancellationToken)
    {
        var any = await _messagesContext
            .Messages
            .AnyAsync(cancellationToken);

        return any;
    }

    public void Add(Message message)
    {
        _messagesContext
            .Messages
            .Add(message);
    }

    public void Update(Message message)
    {
        _messagesContext
            .Messages
            .Update(message);
    }

    public void Delete(Message message)
    {
        _messagesContext
            .Messages
            .Remove(message);
    }
}
