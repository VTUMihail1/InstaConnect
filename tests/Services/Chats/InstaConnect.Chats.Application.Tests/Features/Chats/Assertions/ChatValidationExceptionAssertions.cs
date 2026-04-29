using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Chats.Application.Tests.Features.Chats.Assertions;

public static class ChatValidationExceptionAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldThrowInvalidValidationExceptionForParticipantOneIdAsync(
			IStringMessageTransformer messageTransformer,
			AddChatCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync<AddChatCommandRequest, string, AddChatCommandResponse>(
				p => p.ParticipantOneId,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForParticipantTwoIdAsync(
			IStringMessageTransformer messageTransformer,
			GetChatByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync<GetChatByIdQueryRequest, string, GetChatByIdQueryResponse>(
				p => p.ParticipantTwoId,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForParticipantTwoIdAsync(
			IStringMessageTransformer messageTransformer,
			AddChatCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync<AddChatCommandRequest, string, AddChatCommandResponse>(
				p => p.ParticipantTwoId,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForParticipantTwoNameAsync(
			IStringMessageTransformer messageTransformer,
			GetAllChatsQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllChatsQueryRequest, string, GetAllChatsQueryResponse>(
				p => p.ParticipantTwoName,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
			IStringMessageTransformer messageTransformer,
			GetChatByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync<GetChatByIdQueryRequest, string, GetChatByIdQueryResponse>(
				p => p.CurrentUserId,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
			IStringMessageTransformer messageTransformer,
			GetAllChatsQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllChatsQueryRequest, string, GetAllChatsQueryResponse>(
				p => p.CurrentUserId,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForPageAsync(
			IIntMessageTransformer messageTransformer,
			GetAllChatsQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllChatsQueryRequest, int, GetAllChatsQueryResponse>(
				p => p.Page,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForPageSizeAsync(
			IIntMessageTransformer messageTransformer,
			GetAllChatsQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllChatsQueryRequest, int, GetAllChatsQueryResponse>(
				p => p.PageSize,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForSortOrderAsync(
			IEnumMessageTransformer<CommonSortOrder> messageTransformer,
			GetAllChatsQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllChatsQueryRequest, CommonSortOrder, GetAllChatsQueryResponse>(
				p => p.SortOrder,
				messageTransformer,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForSortTermAsync(
			IEnumMessageTransformer<ChatsSortTerm> messageTransformer,
			GetAllChatsQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowInvalidValidationExceptionAsync<GetAllChatsQueryRequest, ChatsSortTerm, GetAllChatsQueryResponse>(
				p => p.SortTerm,
				messageTransformer,
				request,
				cancellationToken);
		}
	}
}
