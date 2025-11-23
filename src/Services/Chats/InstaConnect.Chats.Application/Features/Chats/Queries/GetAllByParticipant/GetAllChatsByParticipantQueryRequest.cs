namespace InstaConnect.Chats.Application.Features.Chats.Queries.GetAllByParticipant;

public record GetAllChatsByParticipantQueryRequest(
    ChatByParticipantFilterQueryRequest Filter,
    ChatByParticipantSortingQueryRequest Sorting,
    ChatPaginationQueryRequest Pagination)
    : IQueryRequest<GetAllChatsByParticipantQueryResponse>;
