using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;

namespace InstaConnect.ChatMessages.Application.Features.ChatMessages.Queries.GetById;

public record GetChatMessageByIdQuery(string ParticipantOneId, string ParticipantTwoId, string MessageId)
{
    public ChatMessageIncludeQuery? Include { get; private set; }

    public GetChatMessageByIdQuery AddInclude(ChatMessageIncludeQuery include)
    {
        Include = include;

        return this;
    }
};
