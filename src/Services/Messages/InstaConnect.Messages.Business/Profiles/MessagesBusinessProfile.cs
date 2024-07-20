using AutoMapper;
using InstaConnect.Messages.Business.Commands.Messages.AddMessage;
using InstaConnect.Messages.Business.Commands.Messages.UpdateMessage;
using InstaConnect.Messages.Business.Models;
using InstaConnect.Messages.Business.Queries.Messages.GetAllFilteredMessages;
using InstaConnect.Messages.Data.Models.Entities;
using InstaConnect.Messages.Data.Models.Filters;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Data.Models.Enums;
using InstaConnect.Shared.Data.Models.Pagination;

namespace InstaConnect.Messages.Business.Profiles;

internal class MessagesBusinessProfile : Profile
{
    public MessagesBusinessProfile()
    {
        // Read Messages

        CreateMap<UserCreatedEvent, User>();

        CreateMap<UserUpdatedEvent, User>();

        CreateMap<PaginationList<Message>, MessagePaginationCollectionModel>();

        CreateMap<GetAllFilteredMessagesQuery, MessageFilteredCollectionReadQuery>()
            .ConstructUsing(src =>
                 new MessageFilteredCollectionReadQuery
                 {
                     Expression = p => (string.IsNullOrEmpty(src.CurrentUserId) || p.SenderId == src.CurrentUserId) &&
                                       (string.IsNullOrEmpty(src.ReceiverId) || p.ReceiverId == src.ReceiverId) &&
                                       (string.IsNullOrEmpty(src.ReceiverName) || p.Receiver.UserName == src.ReceiverName),
                     SortOrder = Enum.Parse<SortOrder>(src.SortOrder)
                 });

        CreateMap<Message, MessageReadViewModel>()
            .ForMember(dest => dest.SenderName, opt => opt.MapFrom(src => src.Sender.UserName))
            .ForMember(dest => dest.ReceiverName, opt => opt.MapFrom(src => src.Receiver.UserName))
            .ForMember(dest => dest.SenderProfileImage, opt => opt.MapFrom(src => src.Sender.ProfileImage))
            .ForMember(dest => dest.ReceiverProfileImage, opt => opt.MapFrom(src => src.Receiver.ProfileImage));

        // Write Messages

        CreateMap<UserDeletedEvent, MessageFilteredCollectionWriteQuery>()
            .ConstructUsing(src =>
                 new MessageFilteredCollectionWriteQuery
                 {
                     Expression = p => p.SenderId == src.Id
                 });

        CreateMap<AddMessageCommand, GetUserByIdRequest>();

        CreateMap<AddMessageCommand, GetUserByIdRequest>();

        CreateMap<GetUserByIdResponse, Message>()
            .ForMember(dest => dest.ReceiverId, opt => opt.MapFrom(src => src.Id));

        CreateMap<AddMessageCommand, Message>()
            .ForMember(dest => dest.SenderId, opt => opt.MapFrom(src => src.CurrentUserId));

        CreateMap<UpdateMessageCommand, Message>();

        CreateMap<Message, MessageSendModel>();

        CreateMap<Message, MessageWriteViewModel>();

    }
}
