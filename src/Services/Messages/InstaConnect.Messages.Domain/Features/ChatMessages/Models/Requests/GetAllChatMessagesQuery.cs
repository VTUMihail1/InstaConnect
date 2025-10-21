using InstaConnect.Chats.Application.Features.Chats.Queries.GetById;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

namespace InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;

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
