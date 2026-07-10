using InstaConnect.Chats.Tests.Features.ChatMessages.Assertions;
using InstaConnect.Chats.Tests.Features.Chats.Assertions;

namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageExceptionAssertions
{
	extension(IChatMessageCommandService service)
	{
		public async Task ShouldThrowChatNotFoundExceptionAsync(
			AddChatMessageCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.AddAsync(request, cancellationToken);

			await func.ShouldThrowChatNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowChatNotFoundExceptionAsync(
			UpdateChatMessageCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.UpdateAsync(request, cancellationToken);

			await func.ShouldThrowChatNotFoundExceptionAsync(
				r => r.Id.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowChatNotFoundExceptionAsync(
			DeleteChatMessageCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowChatNotFoundExceptionAsync(
				r => r.Id.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowChatMessageNotFoundExceptionAsync(
			UpdateChatMessageCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.UpdateAsync(request, cancellationToken);

			await func.ShouldThrowChatMessageNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowChatMessageNotFoundExceptionAsync(
			DeleteChatMessageCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowChatMessageNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowChatMessageForbiddenExceptionAsync(
			UpdateChatMessageCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.UpdateAsync(request, cancellationToken);

			await func.ShouldThrowChatMessageForbiddenExceptionAsync(
				r => r.Id,
				r => r.Id.Id.ParticipantOneId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowChatMessageForbiddenExceptionAsync(
			DeleteChatMessageCommand request,
			CancellationToken cancellationToken)
		{
			var func = () => service.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowChatMessageForbiddenExceptionAsync(
				r => r.Id,
				r => r.Id.Id.ParticipantOneId,
				request,
				cancellationToken);
		}
	}

	extension(IChatMessageQueryService service)
	{
		public async Task ShouldThrowChatNotFoundExceptionAsync(
			GetAllChatMessagesQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowChatNotFoundExceptionAsync(
				r => r.Filter.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowChatNotFoundExceptionAsync(
			GetChatMessageByIdQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowChatNotFoundExceptionAsync(
				r => r.Id.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowChatMessageNotFoundExceptionAsync(
			GetChatMessageByIdQuery request,
			CancellationToken cancellationToken)
		{
			var func = () => service.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowChatMessageNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}
	}
}
