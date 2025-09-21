using InstaConnect.Chats.Domain.Features.Chats.Models;

namespace InstaConnect.Chats.Application.Features.Chats.Queries.GetAll;

public record GetAllChatsByParticipantQueryRequest(
    ChatByParticipantQueryFilter Filter,
    ChatByParticipantQuerySorting Sorting,
    ChatQueryPagination Pagination)
    : IQueryRequest<GetAllChatsByParticipantQueryResponse>;
