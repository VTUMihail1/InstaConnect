using AutoMapper;
using InstaConnect.Messages.Read.Business.Models;
using InstaConnect.Messages.Read.Business.Queries.Messages.GetAllFilteredMessages;
using InstaConnect.Messages.Read.Data.Models.Entities;
using InstaConnect.Messages.Read.Data.Models.Filters;
using InstaConnect.Shared.Business.Contracts.Messages;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Data.Models.Enums;
using InstaConnect.Shared.Data.Models.Pagination;
using Microsoft.IdentityModel.Tokens;

namespace InstaConnect.Messages.Read.Business.Profiles;

internal class MessagesBusinessProfile : Profile
{
    public MessagesBusinessProfile()
    {
        // Messages

        CreateMap<UserCreatedEvent, User>();

        CreateMap<UserUpdatedEvent, User>();

        CreateMap<MessageCreatedEvent, Message>();

        CreateMap<MessageUpdatedEvent, Message>();

        CreateMap<MessageDeletedEvent, Message>();

        CreateMap<PaginationList<Message>, MessagePaginationCollectionModel>();

        CreateMap<GetAllFilteredMessagesQuery, MessageFilteredCollectionQuery>()
            .ConstructUsing(src =>
                 new MessageFilteredCollectionQuery
                 {
                     Expression = p => (string.IsNullOrEmpty(src.CurrentUserId) || p.SenderId == src.CurrentUserId) &&
                                       (string.IsNullOrEmpty(src.ReceiverId) || p.ReceiverId == src.ReceiverId) &&
                                       (string.IsNullOrEmpty(src.ReceiverName) || p.Receiver.UserName == src.ReceiverName),
                     SortOrder = Enum.Parse<SortOrder>(src.SortOrder)
                 });

        CreateMap<Message, MessageViewModel>()
            .ForMember(dest => dest.SenderName, opt => opt.MapFrom(src => src.Sender.UserName))
            .ForMember(dest => dest.ReceiverName, opt => opt.MapFrom(src => src.Receiver.UserName))
            .ForMember(dest => dest.SenderProfileImage, opt => opt.MapFrom(src => src.Sender.ProfileImage))
            .ForMember(dest => dest.ReceiverProfileImage, opt => opt.MapFrom(src => src.Receiver.ProfileImage));
    }
}
