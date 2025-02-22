using AutoMapper;

using InstaConnect.Messages.Application.Features.Messages.Commands.Add;
using InstaConnect.Messages.Application.Features.Messages.Commands.Update;
using InstaConnect.Messages.Domain.Features.Messages.Models;

namespace InstaConnect.Messages.Application.Features.Messages.Mappings;

internal class MessageCommandProfile : Profile
{
    public MessageCommandProfile()
    {
        CreateMap<Message, MessageSendModel>();

        CreateMap<Message, MessageCommandViewModel>();

    }
}
