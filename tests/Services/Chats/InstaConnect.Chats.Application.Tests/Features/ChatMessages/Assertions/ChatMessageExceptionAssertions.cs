using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageExceptionAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldThrowChatNotFoundExceptionAsync(
			AddChatMessageCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowChatNotFoundExceptionAsync(
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowChatNotFoundExceptionAsync(
			UpdateChatMessageCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowChatNotFoundExceptionAsync(
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowChatNotFoundExceptionAsync(
			DeleteChatMessageCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowChatNotFoundExceptionAsync(
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowChatNotFoundExceptionAsync(
			GetChatMessageByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowChatNotFoundExceptionAsync(
				r => r.CurrentUserId,
				r => r.ParticipantTwoId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowChatNotFoundExceptionAsync(
			GetAllChatMessagesQueryRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowChatNotFoundExceptionAsync(
				r => r.CurrentUserId,
				r => r.ParticipantTwoId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowChatMessageNotFoundExceptionAsync(
			UpdateChatMessageCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowChatMessageNotFoundExceptionAsync(
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId,
				r => r.MessageId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowChatMessageNotFoundExceptionAsync(
			DeleteChatMessageCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowChatMessageNotFoundExceptionAsync(
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId,
				r => r.MessageId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowChatMessageNotFoundExceptionAsync(
			GetChatMessageByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowChatMessageNotFoundExceptionAsync(
				r => r.CurrentUserId,
				r => r.ParticipantTwoId,
				r => r.MessageId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowChatMessageForbiddenExceptionAsync(
			DeleteChatMessageCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowChatMessageForbiddenExceptionAsync(
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId,
				r => r.MessageId,
				r => r.ParticipantOneId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowChatMessageForbiddenExceptionAsync(
			UpdateChatMessageCommandRequest request,
			CancellationToken cancellationToken)
		{
			var func = () => sender.SendAsync(request, cancellationToken);

			await func.ShouldThrowChatMessageForbiddenExceptionAsync(
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId,
				r => r.MessageId,
				r => r.ParticipantOneId,
				request,
				cancellationToken);
		}
	}
}
