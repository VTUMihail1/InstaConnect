using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageValidationAssertions
{
	extension(TestValidationResult<AddChatMessageCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForParticipantOneId(AddChatMessageCommandRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.ParticipantOneId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForParticipantTwoId(AddChatMessageCommandRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.ParticipantTwoId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForContent(AddChatMessageCommandRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Content, messageTransformer);
		}
	}

	extension(TestValidationResult<UpdateChatMessageCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForParticipantOneId(UpdateChatMessageCommandRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.ParticipantOneId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForParticipantTwoId(UpdateChatMessageCommandRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.ParticipantTwoId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForMessageId(UpdateChatMessageCommandRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.MessageId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForContent(UpdateChatMessageCommandRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Content, messageTransformer);
		}
	}

	extension(TestValidationResult<DeleteChatMessageCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForParticipantOneId(DeleteChatMessageCommandRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.ParticipantOneId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForParticipantTwoId(DeleteChatMessageCommandRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.ParticipantTwoId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForMessageId(DeleteChatMessageCommandRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.MessageId, messageTransformer);
		}
	}

	extension(TestValidationResult<GetChatMessageByIdQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForParticipantTwoId(GetChatMessageByIdQueryRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.ParticipantTwoId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForMessageId(GetChatMessageByIdQueryRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.MessageId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentUserId(GetChatMessageByIdQueryRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CurrentUserId, messageTransformer);
		}
	}


	extension(TestValidationResult<GetAllChatMessagesQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForParticipantTwoId(GetAllChatMessagesQueryRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.ParticipantTwoId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentUserId(GetAllChatMessagesQueryRequest request, IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CurrentUserId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPage(GetAllChatMessagesQueryRequest request, IIntMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Page, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPageSize(GetAllChatMessagesQueryRequest request, IIntMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.PageSize, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortOrder(GetAllChatMessagesQueryRequest request, IEnumMessageTransformer<CommonSortOrder> messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.SortOrder, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortTerm(GetAllChatMessagesQueryRequest request, IEnumMessageTransformer<ChatMessagesSortTerm> messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.SortTerm, messageTransformer);
		}
	}
}
