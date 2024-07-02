using AutoMapper;
using InstaConnect.Messages.Business.Commands.Messages.AddMessage;
using InstaConnect.Messages.Business.Commands.Messages.DeleteMessage;
using InstaConnect.Messages.Business.Commands.Messages.UpdateMessage;
using InstaConnect.Messages.Web.Models.Requests.Messages;
using InstaConnect.Shared.Web.Models.Users;

namespace InstaConnect.Messages.Web.Profiles;

public class MessagesWebProfile : Profile
{
    public MessagesWebProfile()
    {
        CreateMap<AddMessageRequest, AddMessageCommand>()
            .ForMember(dest => dest.ReceiverId, opt => opt.MapFrom(src => src.AddMessageBindingModel.ReceiverId))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.AddMessageBindingModel.Content));

        CreateMap<CurrentUserModel, AddMessageCommand>()
            .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.Id));

        CreateMap<UpdateMessageRequest, UpdateMessageCommand>()
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.UpdateMessageBindingModel.Content));

        CreateMap<CurrentUserModel, UpdateMessageCommand>()
            .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.Id));

        CreateMap<DeleteMessageRequest, DeleteMessageCommand>();

        CreateMap<CurrentUserModel, DeleteMessageCommand>()
            .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.Id));
    }
}
