using InstaConnect.Messages.Business.Read.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Messages.Business.Read.Queries.Messages.GetAllMessages;

public class GetAllMessagesQuery : CollectionModel, IQuery<ICollection<MessageViewModel>>
{
}
