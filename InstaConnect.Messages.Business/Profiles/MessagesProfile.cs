using AutoMapper;
using InstaConnect.Messages.Business.Commands.Messages.AddMessage;
using InstaConnect.Messages.Business.Commands.Messages.UpdateMessage;
using InstaConnect.Messages.Business.Models;
using InstaConnect.Messages.Business.Queries.Messages.GetAllFilteredMessages;
using InstaConnect.Messages.Business.Queries.Messages.GetAllMessages;
using InstaConnect.Messages.Data.Models.Entities;
using InstaConnect.Messages.Data.Models.Filters;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Messages.Business.Profiles;

public class MessagesProfile : Profile
{
    public MessagesProfile()
    {
        // Post Comments

        CreateMap<GetAllFilteredMessagesQuery, MessageFilteredCollectionQuery>()
            .ConstructUsing(src =>
                 new MessageFilteredCollectionQuery
                 {
                     Expression = p => (src.SenderId == string.Empty || p.SenderId == src.SenderId) &&
                                       (src.ReceiverId == string.Empty || p.ReceiverId == src.ReceiverId) &&
                                       (src.Content == string.Empty || p.Content.Contains(src.Content))
                 });

        CreateMap<GetAllMessagesQuery, CollectionQuery>();

        CreateMap<AddMessageCommand, GetCurrentUserRequest>();

        CreateMap<Message, ValidateUserByIdRequest>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SenderId));

        CreateMap<GetCurrentUserResponse, Message>();

        CreateMap<AddMessageCommand, Message>();

        CreateMap<UpdateMessageCommand, Message>();

        CreateMap<Message, MessageViewDTO>();
    }
}
