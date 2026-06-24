using InstaConnect.Chats.Domain.Features.ChatMessages.Exceptions;
using InstaConnect.Chats.Domain.Features.ChatMessages.Models.ValueObjects;
using InstaConnect.Chats.Domain.Features.Users.Models.ValueObjects;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageExceptionAssertions
{
	extension(Func<Task> action)
	{
		public async Task ShouldThrowChatMessageNotFoundExceptionAsync<TRequest>(
			Func<TRequest, string> participantOneIdPropertyExpression,
			Func<TRequest, string> participantTwoIdPropertyExpression,
			Func<TRequest, string> messageIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<ChatMessageNotFoundException>(
				ChatMessageExceptionErrorMessages.GetNotFoundMessage(
					new(
						new(
							new(participantOneIdPropertyExpression(request)),
							new(participantTwoIdPropertyExpression(request))),
						messageIdPropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowChatMessageNotFoundExceptionAsync<TRequest>(
			Func<TRequest, ChatMessageId> idPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<ChatMessageNotFoundException>(
				ChatMessageExceptionErrorMessages.GetNotFoundMessage(idPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowChatMessageForbiddenExceptionAsync<TRequest>(
			Func<TRequest, string> participantOneIdPropertyExpression,
			Func<TRequest, string> participantTwoIdPropertyExpression,
			Func<TRequest, string> messageIdPropertyExpression,
			Func<TRequest, string> senderIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<ChatMessageForbiddenException>(
				ChatMessageExceptionErrorMessages.GetForbiddenMessage(
					new(
						new(
							new(participantOneIdPropertyExpression(request)),
							new(participantTwoIdPropertyExpression(request))),
						messageIdPropertyExpression(request)),
					new(senderIdPropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowChatMessageForbiddenExceptionAsync<TRequest>(
			Func<TRequest, ChatMessageId> idPropertyExpression,
			Func<TRequest, UserId> senderIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<ChatMessageForbiddenException>(
				ChatMessageExceptionErrorMessages.GetForbiddenMessage(idPropertyExpression(request), senderIdPropertyExpression(request)),
				cancellationToken);
		}
	}
}
