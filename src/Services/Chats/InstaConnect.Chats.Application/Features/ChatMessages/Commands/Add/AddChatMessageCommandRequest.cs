namespace InstaConnect.Chats.Application.Features.ChatMessages.Commands.Add;

public record AddChatMessageCommandRequest(ChatIdPayload Id, UserIdPayload SenderId, string Content) : ICommandRequest<AddChatMessageCommandResponse>;
