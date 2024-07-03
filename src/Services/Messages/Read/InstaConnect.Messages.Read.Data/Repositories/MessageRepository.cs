using InstaConnect.Messages.Read.Data.Abstractions;
using InstaConnect.Messages.Read.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Messages.Read.Data.Repositories;

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
