using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

public record ChatByParticipantSortingQuery(
    CommonSortOrder Order,
    ChatByParticipantSortProperty Property);
