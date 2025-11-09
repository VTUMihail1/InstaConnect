namespace InstaConnect.Chats.Application.Features.Chats.Queries.GetAllByParticipant;

public record GetAllChatsByParticipantQueryRequest(
    ChatByParticipantQueryFilter Filter,
    ChatByParticipantQuerySorting Sorting,
    ChatQueryPagination Pagination)
    : IQueryRequest<GetAllChatsByParticipantQueryResponse>;
