using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Chats.Domain.Features.Chats.Exceptions;

using MediatR;

namespace InstaConnect.Chats.Application.Tests.Features.Chats.Assertions;

public static class ChatExceptionAssertions
{
    extension(IApplicationSender sender)
    {
        public async Task ShouldThrowParticipantOneNotFoundExceptionForAsync(
        GetAllChatsQueryRequest request,
        CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNotFoundExceptionAsync<GetAllChatsQueryRequest, GetAllChatsQueryResponse>(
                r => r.CurrentUserId,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowParticipantOneNotFoundExceptionForAsync(
        AddChatCommandRequest request,
        CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNotFoundExceptionAsync<AddChatCommandRequest, AddChatCommandResponse>(
                r => r.ParticipantOneId,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowParticipantTwoNotFoundExceptionForAsync(
        AddChatCommandRequest request,
        CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNotFoundExceptionAsync<AddChatCommandRequest, AddChatCommandResponse>(
                r => r.ParticipantTwoId,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowChatNotFoundExceptionAsync(
            GetChatByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowChatNotFoundExceptionAsync<GetChatByIdQueryRequest, GetChatByIdQueryResponse>(
                r => r.CurrentUserId,
                r => r.ParticipantTwoId,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowChatAlreadyExistsExceptionAsync(
            AddChatCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowChatAlreadyExistsExceptionAsync<AddChatCommandRequest, AddChatCommandResponse>(
                r => r.ParticipantOneId,
                r => r.ParticipantTwoId,
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowChatNotFoundExceptionAsync<TRequest>(
            Func<TRequest, string> participantOneIdPropertyExpression,
            Func<TRequest, string> participantTwoIdPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest
        {
            await sender.ShouldThrowAsync<ChatNotFoundException, TRequest>(
                ChatExceptionErrorMessages.GetNotFoundMessage(new(new(participantOneIdPropertyExpression(request)), new(participantTwoIdPropertyExpression(request)))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowChatNotFoundExceptionAsync<TRequest, TResponse>(
            Func<TRequest, string> participantOneIdPropertyExpression,
            Func<TRequest, string> participantTwoIdPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest<TResponse>
        {
            await sender.ShouldThrowAsync<ChatNotFoundException, TRequest, TResponse>(
                ChatExceptionErrorMessages.GetNotFoundMessage(new(new(participantOneIdPropertyExpression(request)), new(participantTwoIdPropertyExpression(request)))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowChatAlreadyExistsExceptionAsync<TRequest>(
            Func<TRequest, string> participantOneIdPropertyExpression,
            Func<TRequest, string> participantTwoIdPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest
        {
            await sender.ShouldThrowAsync<ChatAlreadyExistsException, TRequest>(
                ChatExceptionErrorMessages.GetAlreadyExistsMessage(new(new(participantOneIdPropertyExpression(request)), new(participantTwoIdPropertyExpression(request)))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowChatAlreadyExistsExceptionAsync<TRequest, TResponse>(
            Func<TRequest, string> participantOneIdPropertyExpression,
            Func<TRequest, string> participantTwoIdPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest<TResponse>
        {
            await sender.ShouldThrowAsync<ChatAlreadyExistsException, TRequest, TResponse>(
                ChatExceptionErrorMessages.GetAlreadyExistsMessage(new(new(participantOneIdPropertyExpression(request)), new(participantTwoIdPropertyExpression(request)))),
                request,
                cancellationToken);
        }
    }
}
