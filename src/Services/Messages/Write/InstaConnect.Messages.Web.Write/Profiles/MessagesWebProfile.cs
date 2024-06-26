using AutoMapper;
using InstaConnect.Messages.Business.Commands.Messages.AddMessage;
using InstaConnect.Messages.Business.Commands.Messages.DeleteMessage;
using InstaConnect.Messages.Business.Commands.Messages.UpdateMessage;
using InstaConnect.Messages.Web.Models.Requests.Messages;

namespace InstaConnect.Messages.Web.Profiles;

public class MessagesWebProfile : Profile
{
    public MessagesWebProfile()
    {
        CreateMap<AddMessageRequest, AddMessageCommand>();

        CreateMap<UpdateMessageRequest, UpdateMessageCommand>();

        CreateMap<DeleteMessageRequest, DeleteMessageCommand>();
    }
}
