using InstaConnect.Common.Domain.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

public record ChatsSortingQuery(
    CommonSortOrder Order,
    ChatsSortTerm Term) : ISortingQuery<ChatsSortTerm>;
