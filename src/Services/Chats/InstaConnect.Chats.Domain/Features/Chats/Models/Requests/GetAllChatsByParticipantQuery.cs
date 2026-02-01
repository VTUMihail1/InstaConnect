namespace InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

public record GetAllChatsByParticipantQuery(
    ChatByParticipantFilterQuery Filter,
    CommonSortingQuery<ChatByParticipantSortProperty> Sorting,
    CommonPaginationQuery Pagination)
    : ISortableQuery<ChatByParticipantSortProperty>, IPaginatableQuery, IIncludableQuery<ChatIncludeProperty>
{
    public ChatInclude Include { get; private set; }

    public GetAllChatsByParticipantQuery AddInclude(CommonInclude<ChatIncludeProperty> include)
    {
        Include = include;

        return this;
    }
};
