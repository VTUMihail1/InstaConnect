using InstaConnect.Messages.Data.Abstractions;
using InstaConnect.Messages.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Messages.Data.Repositories;

internal class MessageWriteRepository : BaseWriteRepository<Message>, IMessageWriteRepository
{
    public MessageWriteRepository(MessagesContext messageContext) : base(messageContext)
    {
    }
}
