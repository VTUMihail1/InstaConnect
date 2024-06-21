using InstaConnect.Messages.Business.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Messages.Business.Queries.Messages.GetAllMessages;

public class GetAllMessagesQuery : CollectionModel, IQuery<ICollection<MessageViewModel>>
{
}
