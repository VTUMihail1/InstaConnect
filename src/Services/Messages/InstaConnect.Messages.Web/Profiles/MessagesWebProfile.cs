using AutoMapper;
using InstaConnect.Messages.Business.Commands.Messages.AddMessage;
using InstaConnect.Messages.Business.Commands.Messages.DeleteMessage;
using InstaConnect.Messages.Business.Commands.Messages.UpdateMessage;
using InstaConnect.Messages.Business.Queries.Messages.GetAllFilteredMessages;
using InstaConnect.Messages.Business.Queries.Messages.GetAllMessages;
using InstaConnect.Messages.Business.Queries.Messages.GetMessageById;
using InstaConnect.Messages.Web.Models.Requests.Messages;
using InstaConnect.Shared.Web.Models.Filters;

namespace InstaConnect.Messages.Web.Profiles;

public class MessagesWebProfile : Profile
{
    public MessagesWebProfile()
    {
        // Messages

        CreateMap<CollectionRequest, GetAllMessagesQuery>();

        CreateMap<GetMessageCollectionRequest, GetAllFilteredMessagesQuery>();

        CreateMap<GetMessageByIdRequest, GetMessageByIdQuery>();

        CreateMap<AddMessageRequest, AddMessageCommand>();

        CreateMap<UpdateMessageRequest, UpdateMessageCommand>();

        CreateMap<DeleteMessageRequest, DeleteMessageCommand>();
    }
}
