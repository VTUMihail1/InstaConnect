using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Common.Domain.Features.Messaging.Models;
using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageValidationProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyInvalidValidationForParticipantOneId(
		IStringMessageTransformer messageTransformer,
		AddChatMessageApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.ParticipantOneId,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForParticipantOneId(
		IStringMessageTransformer messageTransformer,
		UpdateChatMessageApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.ParticipantOneId,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForParticipantOneId(
		IStringMessageTransformer messageTransformer,
		DeleteChatMessageApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.ParticipantOneId,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForParticipantOneId(
		IStringMessageTransformer messageTransformer,
		GetChatMessageByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.CurrentUserId,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForParticipantOneId(
		IStringMessageTransformer messageTransformer,
		GetAllChatMessagesApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.CurrentUserId,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForParticipantTwoId(
		IStringMessageTransformer messageTransformer,
		UpdateChatMessageApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.ParticipantTwoId,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForParticipantTwoId(
		IStringMessageTransformer messageTransformer,
		DeleteChatMessageApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.ParticipantTwoId,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForParticipantTwoId(
		IStringMessageTransformer messageTransformer,
		GetChatMessageByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.ParticipantTwoId,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForParticipantTwoId(
		IStringMessageTransformer messageTransformer,
		GetAllChatMessagesApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.ParticipantTwoId,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForParticipantTwoId(
		IStringMessageTransformer messageTransformer,
		AddChatMessageApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.ParticipantTwoId,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForMessageId(
			IStringMessageTransformer messageTransformer,
			UpdateChatMessageApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.MessageId,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForMessageId(
			IStringMessageTransformer messageTransformer,
			DeleteChatMessageApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.MessageId,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForMessageId(
			IStringMessageTransformer messageTransformer,
			GetChatMessageByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.MessageId,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForContent(
			IStringMessageTransformer messageTransformer,
			AddChatMessageApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Body.Content,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForContent(
			IStringMessageTransformer messageTransformer,
			UpdateChatMessageApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Body.Content,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForCurrentUserId(
			IStringMessageTransformer messageTransformer,
			GetChatMessageByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.CurrentUserId,
			   messageTransformer,
			   request);
		}

		public void ShouldSatisfyInvalidValidationForCurrentUserId(
			IStringMessageTransformer messageTransformer,
			GetAllChatMessagesApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.CurrentUserId,
			   messageTransformer,
			   request);
		}

		public void ShouldSatisfyInvalidValidationForPage(
			IIntMessageTransformer messageTransformer,
			GetAllChatMessagesApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Page,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForPageSize(
			IIntMessageTransformer messageTransformer,
			GetAllChatMessagesApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.PageSize,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForSortOrder(
			IEnumMessageTransformer<CommonSortOrder> messageTransformer,
			GetAllChatMessagesApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.SortOrder,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForSortTerm(
			IEnumMessageTransformer<ChatMessagesSortTerm> messageTransformer,
			GetAllChatMessagesApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.SortTerm,
				messageTransformer,
				request);
		}
	}
}
