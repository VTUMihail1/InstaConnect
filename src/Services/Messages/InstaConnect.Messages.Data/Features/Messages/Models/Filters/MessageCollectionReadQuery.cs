using InstaConnect.Shared.Data.Models.Enums;

namespace InstaConnect.Messages.Data.Features.Messages.Models.Filters;

public record MessageCollectionReadQuery(
    string CurrentUserId,
    string ReceiverId,
    string ReceiverName,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize);
