using AutoMapper;
using InstaConnect.Messages.Business.Commands.Messages.AddMessage;
using InstaConnect.Messages.Business.Commands.Messages.UpdateMessage;
using InstaConnect.Messages.Business.Models;
using InstaConnect.Messages.Data.Models.Entities;

namespace InstaConnect.Messages.Business.Profiles;

internal class MessagesCommandProfile : Profile
{
    public MessagesCommandProfile()
    {
        CreateMap<AddMessageCommand, Message>()
            .ConstructUsing(src => new(
                src.Content,
                src.CurrentUserId,
                src.ReceiverId));

        CreateMap<UpdateMessageCommand, Message>();

        CreateMap<Message, MessageSendModel>();

        CreateMap<Message, MessageCommandViewModel>();

    }
}
