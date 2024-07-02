using InstaConnect.Messages.Data.Write.Abstractions;
using InstaConnect.Messages.Data.Write.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Messages.Data.Write.Repositories;

public class MessageRepository : BaseRepository<Message>, IMessageRepository
{
    private readonly MessagesContext _messageContext;

    public MessageRepository(MessagesContext messageContext) : base(messageContext)
    {
        _messageContext = messageContext;
    }
}
