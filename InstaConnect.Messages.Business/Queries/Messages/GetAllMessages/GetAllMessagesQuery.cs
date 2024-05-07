using InstaConnect.Messages.Business.Models;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Messages.Business.Queries.Messages.GetAllMessages;

public class GetAllMessagesQuery : CollectionDTO, IQuery<ICollection<MessageViewDTO>>
{
}
