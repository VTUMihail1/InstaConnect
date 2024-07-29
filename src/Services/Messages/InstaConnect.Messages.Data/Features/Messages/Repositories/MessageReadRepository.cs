using InstaConnect.Messages.Data.Features.Messages.Abstractions;
using InstaConnect.Messages.Data.Features.Messages.Models.Entities;
using InstaConnect.Shared.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Messages.Data.Features.Messages.Repositories;

internal class MessageReadRepository : BaseReadRepository<Message>, IMessageReadRepository
{
    public MessageReadRepository(MessagesContext messageContext) : base(messageContext)
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
