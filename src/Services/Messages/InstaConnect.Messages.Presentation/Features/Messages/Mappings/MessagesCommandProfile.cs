using AutoMapper;
using InstaConnect.Messages.Application.Features.Messages.Commands.Add;
using InstaConnect.Messages.Application.Features.Messages.Commands.Delete;
using InstaConnect.Messages.Application.Features.Messages.Commands.Update;
using InstaConnect.Messages.Application.Features.Messages.Models;
using InstaConnect.Messages.Presentation.Features.Messages.Models.Requests;
using InstaConnect.Messages.Presentation.Features.Messages.Models.Responses;

namespace InstaConnect.Messages.Presentation.Features.Messages.Mappings;

internal class MessagesCommandProfile : Profile
{
    public MessagesCommandProfile()
    {
        CreateMap<AddMessageRequest, AddMessageCommand>()
            .ConstructUsing(src => new(
                src.CurrentUserId,
                src.Body.ReceiverId,
                src.Body.Content));

        CreateMap<UpdateMessageRequest, UpdateMessageCommand>()
            .ConstructUsing(src => new(
                src.Id,
                src.Body.Content,
                src.CurrentUserId));

        CreateMap<DeleteMessageRequest, DeleteMessageCommand>()
            .ConstructUsing(src => new(
                src.Id,
                src.CurrentUserId));

        CreateMap<MessageCommandViewModel, MessageCommandResponse>();
    }
}
