using InstaConnect.Common.Models.Enums;

namespace InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

public record ChatByParticipantSortingQuery(
    SortOrder Order,
    ChatByParticipantSortProperty Property);
