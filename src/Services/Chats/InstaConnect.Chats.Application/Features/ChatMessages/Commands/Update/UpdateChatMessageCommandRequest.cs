namespace InstaConnect.Chats.Application.Features.ChatMessages.Commands.Update;

public record UpdateChatMessageCommandRequest(ChatMessageIdPayload Id, UserIdPayload SenderId, string Content) : ICommandRequest<UpdateChatMessageCommandResponse>;
