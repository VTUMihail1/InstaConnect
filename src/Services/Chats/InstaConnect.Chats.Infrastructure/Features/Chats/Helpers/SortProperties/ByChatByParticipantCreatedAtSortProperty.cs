using System.Linq.Expressions;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.SortProperties;

public class ByChatByParticipantCreatedAtSortProperty : IChatByParticipantSortProperty
{
    public ChatByParticipantSortProperty SortProperty => ChatByParticipantSortProperty.ByCreatedAt;

    public Expression<Func<Chat, object>> Property => p => p.CreatedAtUtc;
}
