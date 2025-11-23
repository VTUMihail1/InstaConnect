namespace InstaConnect.Chats.Application.Features.ChatMessages.Commands.Delete;

public record DeleteChatMessageCommandRequest(ChatMessageId Id, UserId SenderId) : ICommandRequest;
