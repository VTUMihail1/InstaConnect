namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageMatcher
{
	public static GetAllChatMessagesQuery IsGetAllChatMessagesQuery(GetAllChatMessagesQueryRequest request)
	{
		return Matcher.Is<GetAllChatMessagesQuery>(p => p.Matches(request));
	}

	public static GetChatMessageByIdQuery IsGetChatMessageByIdQuery(GetChatMessageByIdQueryRequest request)
	{
		return Matcher.Is<GetChatMessageByIdQuery>(p => p.Matches(request));
	}

	public static AddChatMessageCommand IsAddChatMessageCommand(AddChatMessageCommandRequest request)
	{
		return Matcher.Is<AddChatMessageCommand>(p => p.Matches(request));
	}

	public static UpdateChatMessageCommand IsUpdateChatMessageCommand(UpdateChatMessageCommandRequest request)
	{
		return Matcher.Is<UpdateChatMessageCommand>(p => p.Matches(request));
	}

	public static DeleteChatMessageCommand IsDeleteChatMessageCommand(DeleteChatMessageCommandRequest request)
	{
		return Matcher.Is<DeleteChatMessageCommand>(p => p.Matches(request));
	}
}
