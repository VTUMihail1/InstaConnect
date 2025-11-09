namespace InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

public record GetAllChatsByParticipantQuery(
    ChatByParticipantFilterQuery Filter,
    ChatByParticipantSortingQuery Sorting,
    ChatPaginationQuery Pagination)
{
    public ChatIncludeQuery? Include { get; private set; }

    public GetAllChatsByParticipantQuery AddInclude(ChatIncludeQuery include)
    {
        Include = include;

        return this;
    }
};
