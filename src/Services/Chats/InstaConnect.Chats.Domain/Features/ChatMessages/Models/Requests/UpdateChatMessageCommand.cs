namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

public record UpdateChatMessageCommand(ChatMessageId Id, UserId SenderId, string Content);
