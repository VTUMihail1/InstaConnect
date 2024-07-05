using AutoMapper;
using InstaConnect.Messages.Read.Business.Models;
using InstaConnect.Messages.Read.Business.Queries.Messages.GetAllFilteredMessages;
using InstaConnect.Messages.Read.Data.Models.Entities;
using InstaConnect.Messages.Read.Data.Models.Filters;
using InstaConnect.Shared.Business.Contracts.Messages;
using InstaConnect.Shared.Business.Contracts.Users;

namespace InstaConnect.Messages.Read.Business.Profiles;

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

        CreateMap<Message, MessageViewModel>()
            .ForMember(dest => dest.SenderName, opt => opt.MapFrom(src => src.Sender.UserName))
            .ForMember(dest => dest.ReceiverName, opt => opt.MapFrom(src => src.Receiver.UserName))
            .ForMember(dest => dest.SenderProfileImage, opt => opt.MapFrom(src => src.Sender.ProfileImage))
            .ForMember(dest => dest.ReceiverProfileImage, opt => opt.MapFrom(src => src.Receiver.ProfileImage));
    }
}
