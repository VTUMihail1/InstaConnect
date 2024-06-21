using InstaConnect.Messages.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Messages.Business.Queries.Messages.GetMessageById;

public class GetMessageByIdQuery : IQuery<MessageViewModel>
{
    public string Id { get; set; }
}
