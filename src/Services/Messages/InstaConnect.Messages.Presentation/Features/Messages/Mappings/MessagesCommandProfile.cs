using AutoMapper;
using InstaConnect.Messages.Application.Features.Messages.Commands.AddMessage;
using InstaConnect.Messages.Application.Features.Messages.Commands.DeleteMessage;
using InstaConnect.Messages.Application.Features.Messages.Commands.UpdateMessage;
using InstaConnect.Messages.Application.Features.Messages.Models;
using InstaConnect.Messages.Presentation.Features.Messages.Models.Requests;
using InstaConnect.Messages.Presentation.Features.Messages.Models.Responses;
using InstaConnect.Shared.Presentation.Models.Users;

namespace InstaConnect.Messages.Presentation.Features.Messages.Mappings;

internal class MessagesCommandProfile : Profile
{
    public MessagesCommandProfile()
    {
        CreateMap<(CurrentUserModel, AddMessageRequest), AddMessageCommand>()
            .ConstructUsing(src => new(
                src.Item1.Id,
                src.Item2.AddMessageBindingModel.ReceiverId,
                src.Item2.AddMessageBindingModel.Content));

        CreateMap<(CurrentUserModel, UpdateMessageRequest), UpdateMessageCommand>()
            .ConstructUsing(src => new(
                src.Item2.Id,
                src.Item2.UpdateMessageBindingModel.Content,
                src.Item1.Id));

        CreateMap<(CurrentUserModel, DeleteMessageRequest), DeleteMessageCommand>()
            .ConstructUsing(src => new(
                src.Item2.Id,
                src.Item1.Id));

        CreateMap<MessageCommandViewModel, MessageCommandViewResponse>();
    }
}
