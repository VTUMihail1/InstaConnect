using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

namespace InstaConnect.Chats.Presentation.Features.Chats.Utilities;

public static class ChatDefaultValues
{
	public const ChatsSortTerm SortTerm = ChatsSortTerm.ByCreatedAt;

	public const int Page = 1;

	public const int PageSize = 20;
}
