namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Utilities;

public static class ChatMatcher
{
	public static GetAllChatsQueryRequest IsGetAllChatsQueryRequest(GetAllChatsApiRequest request)
	{
		return Matcher.Is<GetAllChatsQueryRequest>(p => p.Matches(request));
	}

	public static GetChatByIdQueryRequest IsGetChatByIdQueryRequest(GetChatByIdApiRequest request)
	{
		return Matcher.Is<GetChatByIdQueryRequest>(p => p.Matches(request));
	}

	public static AddChatCommandRequest IsAddChatCommandRequest(AddChatApiRequest request)
	{
		return Matcher.Is<AddChatCommandRequest>(p => p.Matches(request));
	}
}
