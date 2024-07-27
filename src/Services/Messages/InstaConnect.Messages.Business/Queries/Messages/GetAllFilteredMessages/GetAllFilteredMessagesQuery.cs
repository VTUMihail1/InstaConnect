using InstaConnect.Messages.Business.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models;
using InstaConnect.Shared.Business.Models.Filters;
using InstaConnect.Shared.Data.Models.Enums;

namespace InstaConnect.Messages.Business.Queries.Messages.GetAllFilteredMessages;

public record GetAllFilteredMessagesQuery(
    string CurrentUserId,
    string ReceiverId,
    string ReceiverName,
    SortOrder SortOrder, 
    string SortPropertyName, 
    int Page, 
    int PageSize) : CollectionModel(SortOrder, SortPropertyName, Page, PageSize), IQuery<MessagePaginationCollectionModel>;
