using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

public record GetAllChatsByParticipantQuery(
    ChatByParticipantFilterQuery Filter,
    CommonSortingQuery<ChatByParticipantSortProperty> Sorting,
    CommonPaginationQuery Pagination)
    : ISortableQuery<ChatByParticipantSortProperty>, IPaginatableQuery, IIncludableQuery<ChatIncludeProperty>
{
    public CommonIncludeQuery<ChatIncludeProperty>? Include { get; private set; }

    public GetAllChatsByParticipantQuery AddInclude(CommonIncludeQuery<ChatIncludeProperty> include)
    {
        Include = include;

        return this;
    }
};
