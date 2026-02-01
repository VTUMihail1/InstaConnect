namespace InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

public record GetChatByIdQuery(ChatId Id)
    : IIncludableQuery<ChatIncludeProperty>
{
    public ChatInclude Include { get; private set; }

    public GetChatByIdQuery AddInclude(CommonInclude<ChatIncludeProperty> include)
    {
        Include = include;

        return this;
    }
};
