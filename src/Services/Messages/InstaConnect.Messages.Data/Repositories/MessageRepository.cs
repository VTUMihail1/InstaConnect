using InstaConnect.Messages.Data.Abstractions;
using InstaConnect.Messages.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Messages.Data.Repositories;

public class MessageRepository : BaseRepository<Message>, IMessageRepository
{
    private readonly MessagesContext _messageContext;

    public MessageRepository(MessagesContext messageContext) : base(messageContext)
    {
        _messageContext = messageContext;
    }
}
