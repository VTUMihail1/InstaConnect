namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

public record GetChatMessageByIdQuery(ChatMessageId Id, UserId UserId)
{
    public ChatMessageIncludeQuery? Include { get; private set; }

    public GetChatMessageByIdQuery AddInclude(ChatMessageIncludeQuery include)
    {
        Include = include;

        return this;
    }
};
