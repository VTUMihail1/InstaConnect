using AutoMapper;

using InstaConnect.Messages.Application.Features.Messages.Commands.Add;
using InstaConnect.Messages.Application.Features.Messages.Commands.Update;
using InstaConnect.Messages.Domain.Features.Messages.Models;

namespace InstaConnect.Messages.Application.Features.Messages.Mappings;

internal class MessageCommandProfile : Profile
{
    public MessageCommandProfile()
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
