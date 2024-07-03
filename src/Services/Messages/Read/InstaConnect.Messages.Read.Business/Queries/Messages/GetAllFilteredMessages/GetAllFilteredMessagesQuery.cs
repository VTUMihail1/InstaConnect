using InstaConnect.Messages.Read.Business.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Messages.Read.Business.Queries.Messages.GetAllFilteredMessages;

public class GetAllFilteredMessagesQuery : CollectionModel, IQuery<ICollection<MessageViewModel>>
{
    public string SenderId { get; set; } = string.Empty;

    public string SenderName { get; set; } = string.Empty;

    public string ReceiverId { get; set; } = string.Empty;

    public string ReceiverName { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}
