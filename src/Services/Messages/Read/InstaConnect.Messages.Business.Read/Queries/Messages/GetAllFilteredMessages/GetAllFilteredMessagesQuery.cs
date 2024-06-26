using InstaConnect.Messages.Business.Read.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Messages.Business.Read.Queries.Messages.GetAllFilteredMessages;

public class GetAllFilteredMessagesQuery : CollectionModel, IQuery<ICollection<MessageViewModel>>
{
    public string SenderId { get; set; }

    public string SenderName { get; set; }

    public string ReceiverId { get; set; }

    public string ReceiverName { get; set; }

    public string Content { get; set; }
}
