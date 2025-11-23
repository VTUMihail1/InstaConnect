namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

public record DeleteChatMessageCommand(ChatMessageId Id, UserId SenderId);
