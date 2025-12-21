using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

public record GetChatMessageByIdQuery(ChatMessageId Id, UserId UserId)
    : IIncludableQuery<ChatMessageIncludeProperty>
{
    public CommonIncludeQuery<ChatMessageIncludeProperty>? Include { get; private set; }

    public GetChatMessageByIdQuery AddInclude(CommonIncludeQuery<ChatMessageIncludeProperty> include)
    {
        Include = include;

        return this;
    }
};
