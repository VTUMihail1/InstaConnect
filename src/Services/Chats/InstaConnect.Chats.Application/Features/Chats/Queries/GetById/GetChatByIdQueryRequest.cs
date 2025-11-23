namespace InstaConnect.Chats.Application.Features.Chats.Queries.GetById;

public record GetChatByIdQueryRequest(ChatIdPayload Id) : IQueryRequest<GetChatByIdQueryResponse>;
