using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Chats.Application.Features.Chats.Models;

public record ChatByParticipantSortingQueryRequest(
    CommonSortOrder Order,
    ChatByParticipantSortProperty Property);
