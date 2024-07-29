using InstaConnect.Messages.Data.Features.Messages.Abstractions;
using InstaConnect.Messages.Data.Features.Messages.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Messages.Data.Features.Messages.Repositories;

internal class MessageWriteRepository : BaseWriteRepository<Message>, IMessageWriteRepository
{
    public MessageWriteRepository(MessagesContext messageContext) : base(messageContext)
    {
    }
}
