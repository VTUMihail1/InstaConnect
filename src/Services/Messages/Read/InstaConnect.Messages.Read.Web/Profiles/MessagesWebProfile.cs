using AutoMapper;
using InstaConnect.Messages.Read.Business.Models;
using InstaConnect.Messages.Read.Business.Queries.Messages.GetAllFilteredMessages;
using InstaConnect.Messages.Read.Business.Queries.Messages.GetMessageById;
using InstaConnect.Messages.Read.Web.Models.Requests.Messages;
using InstaConnect.Messages.Read.Web.Models.Responses;
using InstaConnect.Shared.Web.Models.Users;

namespace InstaConnect.Messages.Read.Web.Profiles;

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
