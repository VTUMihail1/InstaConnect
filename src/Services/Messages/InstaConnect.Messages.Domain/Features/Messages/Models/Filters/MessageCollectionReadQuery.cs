using InstaConnect.Common.Models.Enums;

namespace InstaConnect.Messages.Domain.Features.Messages.Models.Filters;

public record MessageCollectionReadQuery(
    string CurrentUserId,
    string ReceiverId,
    string ReceiverName,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize);
