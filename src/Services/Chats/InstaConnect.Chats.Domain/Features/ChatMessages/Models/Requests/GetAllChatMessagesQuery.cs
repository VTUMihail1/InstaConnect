namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

public record GetAllChatMessagesQuery(
    ChatMessageFilterQuery Filter,
    ChatMessageSortingQuery Sorting,
    ChatMessagePaginationQuery Pagination)
{
    public ChatMessageIncludeQuery? Include { get; private set; }

    public GetAllChatMessagesQuery AddInclude(ChatMessageIncludeQuery include)
    {
        Include = include;

        return this;
    }
};
