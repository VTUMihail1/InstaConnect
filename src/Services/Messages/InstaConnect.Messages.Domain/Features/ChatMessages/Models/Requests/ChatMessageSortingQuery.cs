using InstaConnect.Common.Models.Enums;

namespace InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;

public record ChatMessageSortingQuery(
    SortOrder Order,
    ChatMessageSortProperty Property);
