namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.ValueObjects;

public record ChatMessageId(ChatId Id, string MessageId) : IEntityId;
