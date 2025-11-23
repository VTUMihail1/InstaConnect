namespace InstaConnect.Chats.Application.Features.Chats.Commands.Delete;

public record DeleteChatCommandRequest(ChatIdPayload Id) : ICommandRequest;
