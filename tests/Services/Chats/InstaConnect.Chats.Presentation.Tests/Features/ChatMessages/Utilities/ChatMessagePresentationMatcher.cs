namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageMatcher
{
	public static GetAllChatMessagesQueryRequest IsGetAllChatMessagesQueryRequest(GetAllChatMessagesApiRequest request)
	{
		return Matcher.Is<GetAllChatMessagesQueryRequest>(p => p.Matches(request));
	}

	public static GetChatMessageByIdQueryRequest IsGetChatMessageByIdQueryRequest(GetChatMessageByIdApiRequest request)
	{
		return Matcher.Is<GetChatMessageByIdQueryRequest>(p => p.Matches(request));
	}

	public static AddChatMessageCommandRequest IsAddChatMessageCommandRequest(AddChatMessageApiRequest request)
	{
		return Matcher.Is<AddChatMessageCommandRequest>(p => p.Matches(request));
	}

	public static UpdateChatMessageCommandRequest IsUpdateChatMessageCommandRequest(UpdateChatMessageApiRequest request)
	{
		return Matcher.Is<UpdateChatMessageCommandRequest>(p => p.Matches(request));
	}

	public static DeleteChatMessageCommandRequest IsDeleteChatMessageCommandRequest(DeleteChatMessageApiRequest request)
	{
		return Matcher.Is<DeleteChatMessageCommandRequest>(p => p.Matches(request));
	}
}
