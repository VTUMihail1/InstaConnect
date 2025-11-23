namespace InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

public record GetChatByIdQuery(ChatId Id)
{
    public ChatIncludeQuery? Include { get; private set; }

    public GetChatByIdQuery AddInclude(ChatIncludeQuery include)
    {
        Include = include;

        return this;
    }
};
