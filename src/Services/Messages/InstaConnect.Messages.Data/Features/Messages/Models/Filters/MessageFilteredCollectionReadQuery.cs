using InstaConnect.Messages.Data.Features.Messages.Models.Entities;
using InstaConnect.Shared.Data.Models.Enums;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Messages.Data.Features.Messages.Models.Filters;

public record MessageFilteredCollectionReadQuery(
    string CurrentUserId,
    string ReceiverId,
    string ReceiverName,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize)
    : FilteredCollectionReadQuery<Message>(m => (string.IsNullOrEmpty(CurrentUserId) || m.SenderId == CurrentUserId) &&
                                                (string.IsNullOrEmpty(ReceiverId) || m.ReceiverId == ReceiverId) &&
                                                (string.IsNullOrEmpty(ReceiverName) || m.Receiver!.UserName == ReceiverName),
        SortOrder, SortPropertyName, Page, PageSize);
