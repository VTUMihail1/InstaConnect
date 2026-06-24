using InstaConnect.Chats.Domain.Features.Chats.Exceptions;
using InstaConnect.Chats.Domain.Features.Chats.Models.ValueObjects;

namespace InstaConnect.Chats.Tests.Features.Chats.Assertions;

public static class ChatExceptionAssertions
{
	extension(Func<Task> func)
	{
		public async Task ShouldThrowChatNotFoundExceptionAsync<TRequest>(
			Func<TRequest, string> participantOneIdPropertyExpression,
			Func<TRequest, string> participantTwoIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<ChatNotFoundException>(
				ChatExceptionErrorMessages.GetNotFoundMessage(new(new(participantOneIdPropertyExpression(request)), new(participantTwoIdPropertyExpression(request)))),
				cancellationToken);
		}

		public async Task ShouldThrowChatNotFoundExceptionAsync<TRequest>(
			Func<TRequest, ChatId> idPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<ChatNotFoundException>(
				ChatExceptionErrorMessages.GetNotFoundMessage(idPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowChatAlreadyExistsExceptionAsync<TRequest>(
			Func<TRequest, string> participantOneIdPropertyExpression,
			Func<TRequest, string> participantTwoIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<ChatAlreadyExistsException>(
				ChatExceptionErrorMessages.GetAlreadyExistsMessage(new(new(participantOneIdPropertyExpression(request)), new(participantTwoIdPropertyExpression(request)))),
				cancellationToken);
		}

		public async Task ShouldThrowChatAlreadyExistsExceptionAsync<TRequest>(
			Func<TRequest, ChatId> idPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<ChatAlreadyExistsException>(
				ChatExceptionErrorMessages.GetAlreadyExistsMessage(idPropertyExpression(request)),
				cancellationToken);
		}
	}
}
