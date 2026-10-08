namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageApplicationMatcher
{
	extension(GetAllChatMessagesQueryRequest request)
	{
		public GetAllChatMessagesQuery IsGetAllChatMessagesQuery()
		{
			return Matcher.Is<GetAllChatMessagesQuery>(p => p.Matches(request));
		}
	}

	extension(GetChatMessageByIdQueryRequest request)
	{
		public GetChatMessageByIdQuery IsGetChatMessageByIdQuery()
		{
			return Matcher.Is<GetChatMessageByIdQuery>(p => p.Matches(request));
		}
	}

	extension(AddChatMessageCommandRequest request)
	{
		public AddChatMessageCommand IsAddChatMessageCommand()
		{
			return Matcher.Is<AddChatMessageCommand>(p => p.Matches(request));
		}
	}

	extension(UpdateChatMessageCommandRequest request)
	{
		public UpdateChatMessageCommand IsUpdateChatMessageCommand()
		{
			return Matcher.Is<UpdateChatMessageCommand>(p => p.Matches(request));
		}
	}

	extension(DeleteChatMessageCommandRequest request)
	{
		public DeleteChatMessageCommand IsDeleteChatMessageCommand()
		{
			return Matcher.Is<DeleteChatMessageCommand>(p => p.Matches(request));
		}
	}
}
