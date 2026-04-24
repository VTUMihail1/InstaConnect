using InstaConnect.Common.Domain.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

public record ChatMessagesSortingQuery(
    CommonSortOrder Order,
    ChatMessagesSortTerm Term) : ISortingQuery<ChatMessagesSortTerm>;
