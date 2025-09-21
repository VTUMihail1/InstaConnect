using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Models;

namespace InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Abstractions;
public interface IChatMessageQueryFactory
{
    GetAllChatMessagesQuerySpecification CreateGetAll(GetAllChatMessagesQuery query);

    GetAllChatMessagesTotalCountQuerySpecification CreateGetAllTotalCount(ChatMessageFilterQuery query);

    GetChatMessageByIdQuerySpecification CreateGetById(
        string participantOneId,
        string participantTwoId,
        string messageId);
}
