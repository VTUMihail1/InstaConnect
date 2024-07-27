using AutoMapper;
using InstaConnect.Messages.Business.Commands.Messages.AddMessage;
using InstaConnect.Messages.Business.Commands.Messages.DeleteMessage;
using InstaConnect.Messages.Business.Commands.Messages.UpdateMessage;
using InstaConnect.Messages.Business.Models;
using InstaConnect.Messages.Web.Models.Requests.Messages;
using InstaConnect.Messages.Web.Models.Responses;
using InstaConnect.Shared.Web.Models.Users;

namespace InstaConnect.Messages.Web.Profiles;

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

        CreateMap<MessageCommandViewModel, MessageWriteViewResponse>();
    }
}
