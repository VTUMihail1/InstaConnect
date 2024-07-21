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
            .ConstructUsing(src => new(
                src.Id,
                src.SenderId,
                src.Sender!.UserName,
                src.Sender.ProfileImage,
                src.ReceiverId,
                src.Receiver!.UserName,
                src.Receiver.ProfileImage,
                src.Content));

        // Write Messages

        CreateMap<AddMessageCommand, Message>()
            .ConstructUsing(src => new(
                src.Content,
                src.CurrentUserId,
                src.ReceiverId));

        CreateMap<UpdateMessageCommand, Message>();

        CreateMap<Message, MessageSendModel>();

        CreateMap<Message, MessageWriteViewModel>();

    }
}
