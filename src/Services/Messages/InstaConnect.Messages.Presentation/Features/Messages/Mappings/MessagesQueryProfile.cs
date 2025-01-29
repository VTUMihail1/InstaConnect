using AutoMapper;
using InstaConnect.Messages.Application.Features.Messages.Models;
using InstaConnect.Messages.Application.Features.Messages.Queries.GetAllMessages;
using InstaConnect.Messages.Application.Features.Messages.Queries.GetMessageById;
using InstaConnect.Messages.Presentation.Features.Messages.Models.Requests;
using InstaConnect.Messages.Presentation.Features.Messages.Models.Responses;
using InstaConnect.Shared.Presentation.Models.Users;

namespace InstaConnect.Messages.Presentation.Features.Messages.Mappings;

internal class MessagesQueryProfile : Profile
{
    public MessagesQueryProfile()
    {
        CreateMap<GetAllMessagesRequest, GetAllMessagesQuery>()
            .ConstructUsing(src => new(
                src.CurrentUserId,
                src.ReceiverId,
                src.ReceiverName,
                src.SortOrder,
                src.SortPropertyName,
                src.Page,
                src.PageSize));

        CreateMap<GetMessageByIdRequest, GetMessageByIdQuery>()
            .ConstructUsing(src => new(
                src.Id,
                src.CurrentUserId));

        CreateMap<MessagePaginationQueryViewModel, MessagePaginationCollectionQueryResponse>();

        CreateMap<MessageQueryViewModel, MessageQueryViewResponse>();
    }
}
