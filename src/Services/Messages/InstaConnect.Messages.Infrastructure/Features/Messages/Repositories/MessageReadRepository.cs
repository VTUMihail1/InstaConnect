using InstaConnect.Messages.Domain.Features.Messages.Abstractions;
using InstaConnect.Messages.Domain.Features.Messages.Models.Entities;
using InstaConnect.Messages.Domain.Features.Messages.Models.Filters;
using InstaConnect.Shared.Domain.Models.Pagination;
using InstaConnect.Shared.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Messages.Infrastructure.Features.Messages.Repositories;

internal class MessageReadRepository : IMessageReadRepository
{
    private readonly MessagesContext _messagesContext;

    public MessageReadRepository(MessagesContext messagesContext)
    {
        _messagesContext = messagesContext;
    }

    public async Task<PaginationList<Message>> GetAllAsync(MessageCollectionReadQuery query, CancellationToken cancellationToken)
    {
        var messages = await _messagesContext
            .Messages
            .Include(m => m.Sender)
            .Include(m => m.Receiver)
            .AsSplitQuery()
            .Where(m => (string.IsNullOrEmpty(query.CurrentUserId) || m.SenderId == query.CurrentUserId) &&
                        (string.IsNullOrEmpty(query.ReceiverId) || m.ReceiverId == query.ReceiverId) &&
                        (string.IsNullOrEmpty(query.ReceiverName) || m.Receiver!.UserName.StartsWith(query.ReceiverName)))
            .OrderEntities(query.SortOrder, query.SortPropertyName)
            .ToPagedListAsync(query.Page, query.PageSize, cancellationToken);

        return messages;
    }

    public async Task<Message?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var message = await _messagesContext
            .Messages
            .Include(m => m.Sender)
            .Include(m => m.Receiver)
            .AsSplitQuery()
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return message;
    }
}
