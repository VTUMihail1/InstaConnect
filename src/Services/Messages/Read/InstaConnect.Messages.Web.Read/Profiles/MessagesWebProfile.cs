using AutoMapper;
using InstaConnect.Messages.Business.Read.Models;
using InstaConnect.Messages.Business.Read.Queries.Messages.GetAllFilteredMessages;
using InstaConnect.Messages.Business.Read.Queries.Messages.GetAllMessages;
using InstaConnect.Messages.Business.Read.Queries.Messages.GetMessageById;
using InstaConnect.Messages.Web.Read.Models.Requests.Messages;
using InstaConnect.Messages.Web.Read.Models.Responses;
using InstaConnect.Shared.Web.Models.Filters;

namespace InstaConnect.Messages.Web.Read.Profiles;

public class MessagesWebProfile : Profile
{
    public MessagesWebProfile()
    {
        // Messages

        CreateMap<CollectionRequest, GetAllMessagesQuery>();

        CreateMap<GetMessageCollectionRequest, GetAllFilteredMessagesQuery>();

        CreateMap<GetMessageByIdRequest, GetMessageByIdQuery>();

        CreateMap<MessageViewModel, MessageViewResponse>();
    }
}
