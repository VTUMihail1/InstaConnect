using InstaConnect.Messages.Read.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Messages.Read.Business.Queries.Messages.GetMessageById;

public class GetMessageByIdQuery : IQuery<MessageViewModel>
{
    public string Id { get; set; } = string.Empty;
}
