using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

public record ChatsSortingQuery(
    CommonSortOrder Order,
    ChatsSortTerm Term) : ISortingQuery<ChatsSortTerm>;
