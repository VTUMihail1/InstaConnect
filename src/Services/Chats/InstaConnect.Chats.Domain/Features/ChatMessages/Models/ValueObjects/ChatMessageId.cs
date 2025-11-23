namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.ValueObjects;

public record ChatMessageId(ChatId Id, string MessageId) : IEntityId
{
    public bool Is(ChatMessageId id)
    {
        return Id.Is(id.Id) && id.MessageId == MessageId;
    }
}
