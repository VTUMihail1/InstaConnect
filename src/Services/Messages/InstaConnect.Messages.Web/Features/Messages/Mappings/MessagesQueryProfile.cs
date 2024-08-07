using AutoMapper;
using InstaConnect.Messages.Business.Features.Messages.Models;
using InstaConnect.Messages.Business.Features.Messages.Queries.GetAllFilteredMessages;
using InstaConnect.Messages.Business.Features.Messages.Queries.GetMessageById;
using InstaConnect.Messages.Web.Features.Messages.Models.Requests;
using InstaConnect.Messages.Web.Features.Messages.Models.Responses;
using InstaConnect.Shared.Web.Models.Users;

namespace InstaConnect.Messages.Web.Features.Messages.Mappings;

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
