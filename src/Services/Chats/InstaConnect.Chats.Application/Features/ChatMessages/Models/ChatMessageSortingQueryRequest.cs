using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Chats.Application.Features.ChatMessages.Models;

public record ChatMessageSortingQueryRequest(
    CommonSortOrder Order,
    ChatMessageSortProperty Property);
