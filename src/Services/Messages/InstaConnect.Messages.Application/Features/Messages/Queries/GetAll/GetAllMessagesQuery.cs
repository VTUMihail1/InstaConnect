using InstaConnect.Shared.Application.Models.Filters;

namespace InstaConnect.Messages.Application.Features.Messages.Queries.GetAll;

public record GetAllMessagesQuery(
    string CurrentUserId,
    string ReceiverId,
    string ReceiverName,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize) : CollectionModel(SortOrder, SortPropertyName, Page, PageSize), IQuery<MessagePaginationQueryViewModel>;
