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
        CreateMap<(CurrentUserModel, GetAllMessagesRequest), GetAllMessagesQuery>()
            .ConstructUsing(src => new(
                src.Item1.Id,
                src.Item2.ReceiverId,
                src.Item2.ReceiverName,
                src.Item2.SortOrder,
                src.Item2.SortPropertyName,
                src.Item2.Page,
                src.Item2.PageSize));

        CreateMap<(CurrentUserModel, GetMessageByIdRequest), GetMessageByIdQuery>()
            .ConstructUsing(src => new(
                src.Item2.Id,
                src.Item1.Id));

        CreateMap<MessagePaginationQueryViewModel, MessagePaginationCollectionQueryResponse>();

        CreateMap<MessageQueryViewModel, MessageQueryViewResponse>();
    }
}
