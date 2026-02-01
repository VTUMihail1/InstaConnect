using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

public record ChatMessageSortingQuery(
    CommonSortOrder Order,
    ChatMessageSortProperty Property);
