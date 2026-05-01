using InstaConnect.Chats.Domain.Features.ChatMessages.Exceptions;
using InstaConnect.Common.Application.Features.Messaging.Abstractions;

using MediatR;

namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageExceptionAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldThrowChatNotFoundExceptionAsync(
			AddChatMessageCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowChatNotFoundExceptionAsync<AddChatMessageCommandRequest, AddChatMessageCommandResponse>(
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowChatNotFoundExceptionAsync(
			UpdateChatMessageCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowChatNotFoundExceptionAsync<UpdateChatMessageCommandRequest, UpdateChatMessageCommandResponse>(
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowChatNotFoundExceptionAsync(
			DeleteChatMessageCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowChatNotFoundExceptionAsync(
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowChatNotFoundExceptionAsync(
			GetChatMessageByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowChatNotFoundExceptionAsync<GetChatMessageByIdQueryRequest, GetChatMessageByIdQueryResponse>(
				r => r.CurrentUserId,
				r => r.ParticipantTwoId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowChatNotFoundExceptionAsync(
			GetAllChatMessagesQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowChatNotFoundExceptionAsync<GetAllChatMessagesQueryRequest, GetAllChatMessagesQueryResponse>(
				r => r.CurrentUserId,
				r => r.ParticipantTwoId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowChatMessageNotFoundExceptionAsync(
			UpdateChatMessageCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowChatMessageNotFoundExceptionAsync<UpdateChatMessageCommandRequest, UpdateChatMessageCommandResponse>(
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
			await sender.ShouldThrowChatMessageNotFoundExceptionAsync(
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
			await sender.ShouldThrowChatMessageNotFoundExceptionAsync<GetChatMessageByIdQueryRequest, GetChatMessageByIdQueryResponse>(
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
			await sender.ShouldThrowChatMessageForbiddenExceptionAsync(
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
			await sender.ShouldThrowChatMessageForbiddenExceptionAsync<UpdateChatMessageCommandRequest, UpdateChatMessageCommandResponse>(
				r => r.ParticipantOneId,
				r => r.ParticipantTwoId,
				r => r.MessageId,
				r => r.ParticipantOneId,
				request,
				cancellationToken);
		}

		internal async Task ShouldThrowChatMessageNotFoundExceptionAsync<TRequest>(
			Func<TRequest, string> participantOneIdPropertyExpression,
			Func<TRequest, string> participantTwoIdPropertyExpression,
			Func<TRequest, string> messageIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
			where TRequest : IRequest
		{
			await sender.ShouldThrowAsync<ChatMessageNotFoundException, TRequest>(
				ChatMessageExceptionErrorMessages.GetNotFoundMessage(new(new(new(participantOneIdPropertyExpression(request)), new(participantTwoIdPropertyExpression(request))), messageIdPropertyExpression(request))),
				request,
				cancellationToken);
		}

		internal async Task ShouldThrowChatMessageNotFoundExceptionAsync<TRequest, TResponse>(
			Func<TRequest, string> participantOneIdPropertyExpression,
			Func<TRequest, string> participantTwoIdPropertyExpression,
			Func<TRequest, string> messageIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
			where TRequest : IRequest<TResponse>
		{
			await sender.ShouldThrowAsync<ChatMessageNotFoundException, TRequest, TResponse>(
				ChatMessageExceptionErrorMessages.GetNotFoundMessage(new(new(new(participantOneIdPropertyExpression(request)), new(participantTwoIdPropertyExpression(request))), messageIdPropertyExpression(request))),
				request,
				cancellationToken);
		}

		internal async Task ShouldThrowChatMessageForbiddenExceptionAsync<TRequest>(
			Func<TRequest, string> participantOneIdPropertyExpression,
			Func<TRequest, string> participantTwoIdPropertyExpression,
			Func<TRequest, string> messageIdPropertyExpression,
			Func<TRequest, string> senderIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
			where TRequest : IRequest
		{
			await sender.ShouldThrowAsync<ChatMessageForbiddenException, TRequest>(
				ChatMessageExceptionErrorMessages.GetForbiddenMessage(new(new(new(participantOneIdPropertyExpression(request)), new(participantTwoIdPropertyExpression(request))), messageIdPropertyExpression(request)), new(senderIdPropertyExpression(request))),
				request,
				cancellationToken);
		}

		internal async Task ShouldThrowChatMessageForbiddenExceptionAsync<TRequest, TResponse>(
			Func<TRequest, string> participantOneIdPropertyExpression,
			Func<TRequest, string> participantTwoIdPropertyExpression,
			Func<TRequest, string> messageIdPropertyExpression,
			Func<TRequest, string> senderIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
			where TRequest : IRequest<TResponse>
		{
			await sender.ShouldThrowAsync<ChatMessageForbiddenException, TRequest, TResponse>(
				ChatMessageExceptionErrorMessages.GetForbiddenMessage(new(new(new(participantOneIdPropertyExpression(request)), new(participantTwoIdPropertyExpression(request))), messageIdPropertyExpression(request)), new(senderIdPropertyExpression(request))),
				request,
				cancellationToken);
		}
	}
}
