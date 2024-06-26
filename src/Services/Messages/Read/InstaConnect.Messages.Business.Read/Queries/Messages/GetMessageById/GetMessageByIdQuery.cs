using InstaConnect.Messages.Business.Read.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Messages.Business.Read.Queries.Messages.GetMessageById;

public class GetMessageByIdQuery : IQuery<MessageViewModel>
{
    public string Id { get; set; }
}
