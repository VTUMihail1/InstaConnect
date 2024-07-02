using AutoMapper;
using InstaConnect.Messages.Business.Read.Models;
using InstaConnect.Messages.Business.Read.Queries.Messages.GetAllFilteredMessages;
using InstaConnect.Messages.Business.Read.Queries.Messages.GetMessageById;
using InstaConnect.Messages.Web.Read.Models.Requests.Messages;
using InstaConnect.Messages.Web.Read.Models.Responses;
using InstaConnect.Shared.Web.Models.Users;

namespace InstaConnect.Messages.Web.Read.Profiles;

public class MessagesWebProfile : Profile
{
    public MessagesWebProfile()
    {
        // Messages

        CreateMap<GetAllFilteredMessagesRequest, GetAllFilteredMessagesQuery>();

        CreateMap<CurrentUserModel, GetAllFilteredMessagesQuery>()
            .ForMember(dest => dest.SenderId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.SenderName, opt => opt.MapFrom(src => src.UserName));

        CreateMap<GetMessageByIdRequest, GetMessageByIdQuery>();

        CreateMap<MessageViewModel, MessageViewResponse>();
    }
}
