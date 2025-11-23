namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

public record AddChatMessageCommand(ChatId Id, UserId SenderId, string Content);
