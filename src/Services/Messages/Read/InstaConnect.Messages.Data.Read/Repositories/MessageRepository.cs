using InstaConnect.Messages.Data.Read.Abstractions;
using InstaConnect.Messages.Data.Read.Models.Entities;
using InstaConnect.Shared.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Messages.Data.Read.Repositories;

public class MessageRepository : BaseRepository<Message>, IMessageRepository
{
    private readonly MessagesContext _messageContext;

    public MessageRepository(MessagesContext messageContext) : base(messageContext)
    {
        _messageContext = messageContext;
    }

    protected override IQueryable<Message> IncludeProperties(IQueryable<Message> queryable)
    {
        return queryable
            .Include(m => m.Sender)
            .Include(m => m.Receiver)
            .AsSplitQuery();
    }
}
