using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Chats.Application.Tests.Features.Chats.Assertions;

public static class ChatExceptionAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldThrowParticipantOneNotFoundExceptionForAsync(
		GetAllChatsQueryRequest request,
		CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowUserNotFoundExceptionAsync(
				r => r.CurrentUserId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowParticipantOneNotFoundExceptionForAsync(
		AddChatCommandRequest request,
		CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowUserNotFoundExceptionAsync(
				r => r.ParticipantOneId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowParticipantTwoNotFoundExceptionForAsync(
		AddChatCommandRequest request,
		CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowUserNotFoundExceptionAsync(
				r => r.ParticipantTwoId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowChatNotFoundExceptionAsync(
			GetChatByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowChatNotFoundExceptionAsync(
				r => r.CurrentUserId,
				r => r.ParticipantTwoId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowChatAlreadyExistsExceptionAsync(
			AddChatCommandRequest request,
			CancellationToken cancellationToken)
		{
			var action = () => sender.SendAsync(request, cancellationToken);

			await action.ShouldThrowChatAlreadyExistsExceptionAsync(
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId,
				request,
				cancellationToken);
		}
	}
}
