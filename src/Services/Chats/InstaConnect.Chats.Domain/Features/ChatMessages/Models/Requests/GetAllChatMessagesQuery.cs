namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

public record GetAllChatMessagesQuery(
    ChatMessageFilterQuery Filter,
    ChatMessageSortingQuery Sorting,
    CommonPaginationQuery Pagination)
    : ISortableQuery<ChatMessageSortProperty>, IPaginatableQuery, IIncludableQuery<ChatMessageIncludeProperty>
{
    public ChatMessageInclude Include { get; private set; }

    public GetAllChatMessagesQuery AddInclude(CommonInclude<ChatMessageIncludeProperty> include)
    {
        Include = include;

        return this;
    }
};
