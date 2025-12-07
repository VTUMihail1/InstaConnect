using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Chats.Application.Features.Chats.Queries.GetAllByParticipant;

public record GetAllChatsByParticipantQueryRequest(
    string ParticipantId,
    string ParticipantName,
    CommonSortOrder SortOrder,
    ChatByParticipantSortProperty SortProperty,
    int Page,
    int PageSize)
    : IQueryRequest<GetAllChatsByParticipantQueryResponse>;
