using AutoMapper;
using InstaConnect.Messages.Business.Features.Messages.Commands.AddMessage;
using InstaConnect.Messages.Business.Features.Messages.Commands.UpdateMessage;
using InstaConnect.Messages.Business.Features.Messages.Models;
using InstaConnect.Messages.Data.Features.Messages.Models.Entities;

namespace InstaConnect.Messages.Business.Features.Messages.Mappings;

internal class MessagesCommandProfile : Profile
{
    public MessagesCommandProfile()
    {
        CreateMap<AddMessageCommand, Message>()
            .ConstructUsing(src => new(
                src.Content,
                src.CurrentUserId,
                src.ReceiverId));

        CreateMap<UpdateMessageCommand, Message>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<Message, MessageSendModel>();

        CreateMap<Message, MessageCommandViewModel>();

    }
}
