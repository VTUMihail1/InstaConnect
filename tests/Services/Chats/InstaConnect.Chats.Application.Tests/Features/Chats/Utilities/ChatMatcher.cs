namespace InstaConnect.Chats.Application.Tests.Features.Chats.Utilities;

public static class ChatMatcher
{
	public static GetAllChatsQuery IsGetAllChatsQuery(GetAllChatsQueryRequest request)
	{
		return Matcher.Is<GetAllChatsQuery>(p => p.Matches(request));
	}

	public static GetChatByIdQuery IsGetChatByIdQuery(GetChatByIdQueryRequest request)
	{
		return Matcher.Is<GetChatByIdQuery>(p => p.Matches(request));
	}

	public static AddChatCommand IsAddChatCommand(AddChatCommandRequest request)
	{
		return Matcher.Is<AddChatCommand>(p => p.Matches(request));
	}
}
