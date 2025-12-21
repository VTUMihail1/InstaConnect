using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

public record GetAllChatMessagesQuery(
    ChatMessageFilterQuery Filter,
    CommonSortingQuery<ChatMessageSortProperty> Sorting,
    CommonPaginationQuery Pagination)
    : ISortableQuery<ChatMessageSortProperty>, IPaginatableQuery, IIncludableQuery<ChatMessageIncludeProperty>
{
    public CommonIncludeQuery<ChatMessageIncludeProperty>? Include { get; private set; }

    public GetAllChatMessagesQuery AddInclude(CommonIncludeQuery<ChatMessageIncludeProperty> include)
    {
        Include = include;

        return this;
    }
};
