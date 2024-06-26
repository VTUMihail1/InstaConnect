using AutoMapper;
using InstaConnect.Messages.Business.Read.Models;
using InstaConnect.Messages.Business.Read.Queries.Messages.GetAllFilteredMessages;
using InstaConnect.Messages.Business.Read.Queries.Messages.GetAllMessages;
using InstaConnect.Messages.Data.Read.Models.Entities;
using InstaConnect.Messages.Data.Read.Models.Filters;
using InstaConnect.Shared.Business.Contracts.Messages;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Messages.Business.Read.Profiles;

public class MessagesBusinessProfile : Profile
{
    public MessagesBusinessProfile()
    {
        // Messages

        CreateMap<UserCreatedEvent, User>();

        CreateMap<UserUpdatedEvent, User>();

        CreateMap<MessageCreatedEvent, Message>();

        CreateMap<MessageUpdatedEvent, Message>();

        CreateMap<MessageDeletedEvent, Message>();

        CreateMap<GetAllFilteredMessagesQuery, MessageFilteredCollectionQuery>()
            .ConstructUsing(src =>
                 new MessageFilteredCollectionQuery
                 {
                     Expression = p => (src.SenderId == string.Empty || p.SenderId == src.SenderId) &&
                                       (src.ReceiverId == string.Empty || p.ReceiverId == src.ReceiverId) &&
                                       (src.Content == string.Empty || p.Content.Contains(src.Content))
                 });

        CreateMap<GetAllMessagesQuery, CollectionQuery>();

        CreateMap<Message, MessageViewModel>()
            .ForMember(dest => dest.SenderName, opt => opt.MapFrom(src => src.Sender.UserName))
            .ForMember(dest => dest.ReceiverName, opt => opt.MapFrom(src => src.Receiver.UserName));
    }
}
