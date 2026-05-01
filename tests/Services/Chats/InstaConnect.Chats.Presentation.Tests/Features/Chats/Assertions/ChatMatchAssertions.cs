using InstaConnect.Chats.Presentation.Tests.Features.Chats.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;

namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Assertions;

public static class ChatMatchAssertions
{
	extension(AddChatApiResponse response)
	{
		public void ShouldSatisfy(
		Chat chat,
		AddChatApiRequest request)
		{
			response.ShouldSatisfy(p => p.Matches(chat, request));
		}
	}

	extension(GetChatByIdApiResponse response)
	{
		public void ShouldSatisfy(
		Chat chat,
		GetChatByIdApiRequest request)
		{
			response.ShouldSatisfy(p => p.Matches(chat, request));
		}

		public void ShouldSatisfyInverted(
		Chat chat,
		GetChatByIdApiRequest request)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(chat, request));
		}
	}

	extension(GetAllChatsApiResponse response)
	{
		public void ShouldSatisfy(
		User participantOne,
		ICollection<Chat> chats,
		GetAllChatsApiRequest request)
		{
			response.ShouldSatisfy(p => p.Matches(participantOne, chats, request));
		}

		public void ShouldSatisfy(
			User participantOne,
			ICollection<Chat> chats,
			GetAllChatsApiRequest request,
			ISortEnumTermTransformer<Chat> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(participantOne, chats, request, termTransformer));
		}

		public void ShouldSatisfyInverted(
		User participantTwo,
		ICollection<Chat> chats,
		GetAllChatsApiRequest request)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(participantTwo, chats, request));
		}

		public void ShouldSatisfyInverted(
			User participantTwo,
			ICollection<Chat> chats,
			GetAllChatsApiRequest request,
			ISortEnumTermTransformer<Chat> termTransformer)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(participantTwo, chats, request, termTransformer));
		}
	}

	extension(ActionResult<AddChatApiResponse> response)
	{
		public void ShouldSatisfy(
		Chat chat,
		AddChatApiRequest request)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(chat, request));
		}
	}

	extension(ActionResult<GetChatByIdApiResponse> response)
	{
		public void ShouldSatisfy(
		Chat chat,
		GetChatByIdApiRequest request)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(chat, request));
		}
	}

	extension(ActionResult<GetAllChatsApiResponse> response)
	{
		public void ShouldSatisfy(
		User participantOne,
		ICollection<Chat> chats,
		GetAllChatsApiRequest request)
		{
			response.ShouldBeActionResultAndSatisfy(p => p.Matches(participantOne, chats, request));
		}
	}

	extension(Chat chat)
	{
		public void ShouldSatisfy(AddChatApiRequest request)
		{
			chat.ShouldSatisfy(p => p.Matches(request));
		}
	}
}
