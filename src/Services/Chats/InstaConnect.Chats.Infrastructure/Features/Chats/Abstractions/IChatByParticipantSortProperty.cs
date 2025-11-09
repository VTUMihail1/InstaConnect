using System.Linq.Expressions;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

public interface IChatByParticipantSortProperty
{
    public ChatByParticipantSortProperty SortProperty { get; }

    public Expression<Func<Chat, object>> Property { get; }
}
