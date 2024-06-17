using InstaConnect.Messages.Business.Models;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Messages.Business.Queries.Messages.GetAllFilteredMessages;

public class GetAllFilteredMessagesQuery : CollectionDTO, IQuery<ICollection<MessageViewModel>>
{
    public string SenderId { get; set; }

    public string SenderName { get; set; }

    public string ReceiverId { get; set; }

    public string ReceiverName { get; set; }

    public string Content { get; set; }
}
