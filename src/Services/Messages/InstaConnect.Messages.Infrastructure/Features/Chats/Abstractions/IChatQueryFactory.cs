using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Infrastructure.Features.Chats.Models;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;
public interface IChatQueryFactory
{
    GetAllChatsByParticipantQuerySpecification CreateGetAllByParticipant(GetAllChatsByParticipantQuery query);

    GetAllChatsByParticipantTotalCountQuerySpecification CreateGetAllByParticipantTotalCount(ChatByParticipantFilterQuery query);

    GetChatByIdQuerySpecification CreateGetById(
        string participantOneId,
        string participantTwoId);
}
