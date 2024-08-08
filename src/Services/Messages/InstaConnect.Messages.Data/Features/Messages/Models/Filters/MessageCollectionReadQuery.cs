using InstaConnect.Messages.Data.Features.Messages.Models.Entities;
using InstaConnect.Shared.Data.Models.Enums;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Messages.Data.Features.Messages.Models.Filters;

public record MessageCollectionReadQuery(
    string CurrentUserId,
    string ReceiverId,
    string ReceiverName,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize)
    : CollectionReadQuery<Message>(m => (string.IsNullOrEmpty(CurrentUserId) || m.SenderId == CurrentUserId) &&
                                                (string.IsNullOrEmpty(ReceiverId) || m.ReceiverId == ReceiverId) &&
                                                (string.IsNullOrEmpty(ReceiverName) || m.Receiver!.UserName.StartsWith(ReceiverName)),
        SortOrder, SortPropertyName, Page, PageSize);
