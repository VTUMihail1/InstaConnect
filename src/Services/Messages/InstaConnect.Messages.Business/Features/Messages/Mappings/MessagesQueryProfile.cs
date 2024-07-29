using AutoMapper;
using InstaConnect.Messages.Business.Features.Messages.Models;
using InstaConnect.Messages.Business.Features.Messages.Queries.GetAllFilteredMessages;
using InstaConnect.Messages.Data.Features.Messages.Models.Entities;
using InstaConnect.Messages.Data.Features.Messages.Models.Filters;
using InstaConnect.Shared.Data.Models.Pagination;

namespace InstaConnect.Messages.Business.Features.Messages.Mappings;

internal class MessagesQueryProfile : Profile
{
    public MessagesQueryProfile()
    {
        CreateMap<PaginationList<Message>, MessagePaginationCollectionModel>();

        CreateMap<GetAllFilteredMessagesQuery, MessageFilteredCollectionReadQuery>();

        CreateMap<Message, MessageQueryViewModel>()
            .ConstructUsing(src => new(
                src.Id,
                src.SenderId,
                src.Sender!.UserName,
                src.Sender.ProfileImage,
                src.ReceiverId,
                src.Receiver!.UserName,
                src.Receiver.ProfileImage,
                src.Content));

    }
}
