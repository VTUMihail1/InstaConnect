namespace InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

public record GetAllChatsByParticipantQuery(
    ChatByParticipantFilterQuery Filter,
    ChatByParticipantSortingQuery Sorting,
    ChatPaginationQuery Pagination);
