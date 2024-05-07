using InstaConnect.Data.Models.Entities;
using InstaConnect.Messages.Data.Abstractions.Repositories;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Messages.Data.Repositories;

public class MessageRepository : BaseRepository<Message>, IMessageRepository
{
    private readonly MessageContext _messageContext;

    public MessageRepository(MessageContext messageContext) : base(messageContext)
    {
        _messageContext = messageContext;
    }
}
