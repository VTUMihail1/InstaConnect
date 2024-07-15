using InstaConnect.Messages.Read.Data.Abstractions;
using InstaConnect.Messages.Read.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Messages.Read.Data.Repositories;

internal class MessageRepository : BaseRepository<Message>, IMessageRepository
{
    public MessageRepository(MessagesContext messageContext) : base(messageContext)
    {
    }

    protected override IQueryable<Message> IncludeProperties(IQueryable<Message> queryable)
    {
        return queryable
            .Include(m => m.Sender)
            .Include(m => m.Receiver)
            .AsSplitQuery();
    }
}
