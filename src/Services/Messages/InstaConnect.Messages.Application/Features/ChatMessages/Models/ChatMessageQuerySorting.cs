using InstaConnect.Common.Models.Enums;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;

namespace InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models;

public record ChatMessageQuerySorting(
    SortOrder Order,
    ChatMessageSortProperty Property);
