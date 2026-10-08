using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

public interface IChatMessageResponseFluent : IMongoDbResponseFluent<ChatMessageResponse>
{
	public IChatMessageResponseFluent ApplySorting(ChatMessagesSortingQuery query);
	public IChatMessageResponseFluent ApplyPagination(ChatMessagesPaginationQuery query);
}
