namespace InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetById;

public record GetChatMessageByIdQueryRequest(ChatMessageIdPayload Id, UserIdPayload SenderId) : IQueryRequest<GetChatMessageByIdQueryResponse>;
