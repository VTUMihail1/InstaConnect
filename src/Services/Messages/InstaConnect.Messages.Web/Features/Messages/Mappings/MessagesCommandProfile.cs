using AutoMapper;
using InstaConnect.Messages.Business.Features.Messages.Commands.AddMessage;
using InstaConnect.Messages.Business.Features.Messages.Commands.DeleteMessage;
using InstaConnect.Messages.Business.Features.Messages.Commands.UpdateMessage;
using InstaConnect.Messages.Business.Features.Messages.Models;
using InstaConnect.Messages.Web.Features.Messages.Models.Requests;
using InstaConnect.Messages.Web.Features.Messages.Models.Responses;
using InstaConnect.Shared.Web.Models.Users;

namespace InstaConnect.Messages.Web.Features.Messages.Mappings;

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
