using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

public record GetChatByIdQuery(ChatId Id)
    : IIncludableQuery<ChatIncludeProperty>
{
    public CommonIncludeQuery<ChatIncludeProperty>? Include { get; private set; }

    public GetChatByIdQuery AddInclude(CommonIncludeQuery<ChatIncludeProperty> include)
    {
        Include = include;

        return this;
    }
};
