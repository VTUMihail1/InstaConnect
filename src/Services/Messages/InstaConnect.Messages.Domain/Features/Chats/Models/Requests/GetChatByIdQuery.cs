using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

namespace InstaConnect.Chats.Application.Features.Chats.Queries.GetById;

public record GetChatByIdQuery(string ParticipantOneId, string ParticipantTwoId)
{
    public ChatIncludeQuery? Include { get; private set; }

    public GetChatByIdQuery AddInclude(ChatIncludeQuery include)
    {
        Include = include;

        return this;
    }
};
