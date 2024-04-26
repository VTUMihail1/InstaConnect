using InstaConnect.Messages.Business.Models;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Messages.Business.Queries.PostComments.GetAllPostComments
{
    public class GetAllMessagesQuery : CollectionDTO, IQuery<ICollection<MessageViewDTO>>
    {
    }
}
