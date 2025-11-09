using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Chats.Application.Features.ChatMessages.Models;

public record ChatMessageQuerySorting(
    SortOrder Order,
    ChatMessageSortProperty Property);
