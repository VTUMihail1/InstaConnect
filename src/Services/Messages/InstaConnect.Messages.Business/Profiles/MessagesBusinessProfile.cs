using AutoMapper;
using InstaConnect.Messages.Business.Commands.Messages.AddMessage;
using InstaConnect.Messages.Business.Commands.Messages.UpdateMessage;
using InstaConnect.Messages.Business.Models;
using InstaConnect.Messages.Business.Queries.Messages.GetAllFilteredMessages;
using InstaConnect.Messages.Business.Queries.Messages.GetAllMessages;
using InstaConnect.Messages.Data.Models.Entities;
using InstaConnect.Messages.Data.Models.Filters;
using InstaConnect.Shared.Business.Contracts;
using InstaConnect.Shared.Business.Models.Users;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Messages.Business.Profiles;

public class MessagesBusinessProfile : Profile
{
    public MessagesBusinessProfile()
    {
        // Messages

        CreateMap<UserDeletedEvent, MessageFilteredCollectionQuery>()
            .ConstructUsing(src =>
                 new MessageFilteredCollectionQuery
                 {
                     Expression = p => p.SenderId == src.Id
                 });

        CreateMap<GetAllFilteredMessagesQuery, MessageFilteredCollectionQuery>()
            .ConstructUsing(src =>
                 new MessageFilteredCollectionQuery
                 {
                     Expression = p => (src.SenderId == string.Empty || p.SenderId == src.SenderId) &&
                                       (src.SenderName == string.Empty || p.SenderName == src.SenderName) &&
                                       (src.ReceiverId == string.Empty || p.ReceiverId == src.ReceiverId) &&
                                       (src.ReceiverName == string.Empty || p.ReceiverName == src.ReceiverName) &&
                                       (src.Content == string.Empty || p.Content.Contains(src.Content))
                 });

        CreateMap<GetAllMessagesQuery, CollectionQuery>();

        CreateMap<AddMessageCommand, GetUserByIdRequest>();

        CreateMap<CurrentUserDetails, Message>()
            .ForMember(dest => dest.SenderId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.SenderName, opt => opt.MapFrom(src => src.UserName));

        CreateMap<GetUserByIdResponse, Message>()
            .ForMember(dest => dest.ReceiverId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.ReceiverName, opt => opt.MapFrom(src => src.UserName));

        CreateMap<AddMessageCommand, Message>();

        CreateMap<UpdateMessageCommand, Message>();

        CreateMap<Message, MessageViewModel>();
    }
}
