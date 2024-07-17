using InstaConnect.Messages.Write.Data.Abstractions;
using InstaConnect.Messages.Write.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Messages.Write.Data.Repositories;

public class MessageRepository : BaseWriteRepository<Message>, IMessageRepository
{
    public MessageRepository(MessagesContext messageContext) : base(messageContext)
    {
    }
}
