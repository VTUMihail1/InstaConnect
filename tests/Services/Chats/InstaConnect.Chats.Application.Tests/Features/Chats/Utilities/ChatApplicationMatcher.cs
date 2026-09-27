namespace InstaConnect.Chats.Application.Tests.Features.Chats.Utilities;

public static class ChatApplicationMatcher
{
	extension(GetAllChatsQueryRequest request)
	{
		public GetAllChatsQuery IsGetAllChatsQuery()
		{
			return Matcher.Is<GetAllChatsQuery>(p => p.Matches(request));
		}
	}

	extension(GetChatByIdQueryRequest request)
	{
		public GetChatByIdQuery IsGetChatByIdQuery()
		{
			return Matcher.Is<GetChatByIdQuery>(p => p.Matches(request));
		}
	}

	extension(AddChatCommandRequest request)
	{
		public AddChatCommand IsAddChatCommand()
		{
			return Matcher.Is<AddChatCommand>(p => p.Matches(request));
		}
	}
}
