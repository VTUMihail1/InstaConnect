using InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageMatchAssertions
{
	extension(AddChatMessageApiResponse response)
	{
		public void ShouldSatisfy(
		AddChatMessageApiRequest request,
		ChatMessage chatMessage)
		{
			response.ShouldSatisfy(p => p.Matches(request, chatMessage));
		}
	}

	extension(UpdateChatMessageApiResponse response)
	{
		public void ShouldSatisfy(
		UpdateChatMessageApiRequest request,
		ChatMessage chatMessage)
		{
			response.ShouldSatisfy(p => p.Matches(request, chatMessage));
		}
	}

	extension(GetChatMessageByIdApiResponse response)
	{
		public void ShouldSatisfy(
		GetChatMessageByIdApiRequest request,
		ChatMessage chatMessage)
		{
			response.ShouldSatisfy(p => p.Matches(request, chatMessage));
		}

		public void ShouldSatisfyInverted(GetChatMessageByIdApiRequest request, ChatMessage chatMessage)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(request, chatMessage));
		}
	}

	extension(GetAllChatMessagesApiResponse response)
	{
		public void ShouldSatisfy(
		GetAllChatMessagesApiRequest request,
		Chat chat,
		ICollection<ChatMessage> chatMessages)
		{
			response.ShouldSatisfy(p => p.Matches(request, chat, chatMessages));
		}

		public void ShouldSatisfy(
			GetAllChatMessagesApiRequest request,
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			ISortEnumTermTransformer<ChatMessage> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(request, chat, chatMessages, termTransformer));
		}

		public void ShouldSatisfyInverted(GetAllChatMessagesApiRequest request, Chat chat, ICollection<ChatMessage> chatMessages)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(request, chat, chatMessages));
		}

		public void ShouldSatisfyInverted(GetAllChatMessagesApiRequest request, Chat chat, ICollection<ChatMessage> chatMessages, ISortEnumTermTransformer<ChatMessage> termTransformer)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(request, chat, chatMessages, termTransformer));
		}
	}

	extension(ActionResult<AddChatMessageApiResponse> response)
	{
		public void ShouldSatisfy(
		AddChatMessageApiRequest request,
		ChatMessage chatMessage)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, chatMessage));
		}
	}

	extension(ActionResult<UpdateChatMessageApiResponse> response)
	{
		public void ShouldSatisfy(
		UpdateChatMessageApiRequest request,
		ChatMessage chatMessage)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, chatMessage));
		}
	}

	extension(ActionResult<GetChatMessageByIdApiResponse> response)
	{
		public void ShouldSatisfy(
		GetChatMessageByIdApiRequest request,
		ChatMessage chatMessage)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, chatMessage));
		}
	}

	extension(ActionResult<GetAllChatMessagesApiResponse> response)
	{
		public void ShouldSatisfy(
		GetAllChatMessagesApiRequest request,
		Chat chat,
		ICollection<ChatMessage> chatMessages)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(request, chat, chatMessages));
		}
	}

	extension(ChatMessage chatMessage)
	{
		public void ShouldSatisfy(AddChatMessageApiRequest request)
		{
			chatMessage.ShouldSatisfy(p => p.Matches(request));
		}

		public void ShouldSatisfy(UpdateChatMessageApiRequest request)
		{
			chatMessage.ShouldSatisfy(p => p.Matches(request));
		}

		public void ShouldSatisfyInverted(AddChatMessageApiRequest request)
		{
			chatMessage.ShouldSatisfy(p => p.MatchesInverted(request));
		}

		public void ShouldSatisfyInverted(UpdateChatMessageApiRequest request)
		{
			chatMessage.ShouldSatisfy(p => p.MatchesInverted(request));
		}
	}
}
