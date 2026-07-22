using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Chats.Application.Tests.Features.Chats.Assertions;

public static class ChatValidationAssertions
{
	extension(TestValidationResult<GetChatByIdQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForParticipantTwoId(
			GetChatByIdQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.ParticipantTwoId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentUserId(
			GetChatByIdQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CurrentUserId, messageTransformer);
		}
	}

	extension(TestValidationResult<AddChatCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForParticipantOneId(
			AddChatCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.ParticipantOneId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForParticipantTwoId(
			AddChatCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.ParticipantTwoId, messageTransformer);
		}
	}

	extension(TestValidationResult<GetAllChatsQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForParticipantTwoName(
			GetAllChatsQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.ParticipantTwoName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentUserId(
			GetAllChatsQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CurrentUserId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPage(
			GetAllChatsQueryRequest request,
			IIntMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Page, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPageSize(
			GetAllChatsQueryRequest request,
			IIntMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.PageSize, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortOrder(
			GetAllChatsQueryRequest request,
			IEnumMessageTransformer<CommonSortOrder> messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.SortOrder, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortTerm(
			GetAllChatsQueryRequest request,
			IEnumMessageTransformer<ChatsSortTerm> messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.SortTerm, messageTransformer);
		}
	}
}
