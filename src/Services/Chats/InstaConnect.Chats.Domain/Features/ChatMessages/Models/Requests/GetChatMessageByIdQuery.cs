namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

public record GetChatMessageByIdQuery(string ParticipantOneId, string ParticipantTwoId, string MessageId)
{
    public ChatMessageIncludeQuery? Include { get; private set; }

    public GetChatMessageByIdQuery AddInclude(ChatMessageIncludeQuery include)
    {
        Include = include;

        return this;
    }
};
