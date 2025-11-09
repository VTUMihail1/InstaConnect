using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Chats.Application.Features.Chats.Models;

public record ChatByParticipantQuerySorting(
    SortOrder Order,
    ChatByParticipantSortProperty Property);
