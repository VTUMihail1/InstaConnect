using System.Linq.Expressions;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.SortProperties;

public class ByChatByParticipantTwoNameSortProperty : IChatByParticipantSortProperty
{
    public ChatByParticipantSortProperty SortProperty => ChatByParticipantSortProperty.ByParticipantName;

    public Expression<Func<Chat, object>> Property => p => p.ParticipantTwo!.Name.Value;
}
