using AutoMapper;
using InstaConnect.Messages.Application.Features.Messages.Models;
using InstaConnect.Messages.Application.Features.Messages.Queries.GetAllMessages;
using InstaConnect.Messages.Domain.Features.Messages.Models.Entities;
using InstaConnect.Messages.Domain.Features.Messages.Models.Filters;
using InstaConnect.Shared.Domain.Models.Pagination;

namespace InstaConnect.Messages.Application.Features.Messages.Mappings;

internal class MessageQueryProfile : Profile
{
    public MessageQueryProfile()
    {
        CreateMap<PaginationList<Message>, MessagePaginationQueryViewModel>();

        CreateMap<GetAllMessagesQuery, MessageCollectionReadQuery>();

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
