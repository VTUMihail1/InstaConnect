namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

public record GetChatMessageByIdQuery(ChatMessageId Id, UserId UserId)
    : IIncludableQuery<ChatMessageIncludeProperty>
{
    public ChatMessageInclude Include { get; private set; }

    public GetChatMessageByIdQuery AddInclude(CommonInclude<ChatMessageIncludeProperty> include)
    {
        Include = include;

        return this;
    }
};
