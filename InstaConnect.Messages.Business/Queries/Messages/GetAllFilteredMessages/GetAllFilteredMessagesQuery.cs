using InstaConnect.Messages.Business.Models;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Filters;
using MediatR;

namespace InstaConnect.Messages.Business.Queries.PostComments.GetAllFilteredPostComments
{
    public class GetAllFilteredMessagesQuery : CollectionDTO, IQuery<ICollection<MessageViewDTO>>
    {
        public string SenderId { get; set; }

        public string ReceiverId { get; set; }

        public string Content { get; set; }
    }
}
