using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Follows.Domain.Features.Follows.Exceptions;

using MediatR;

namespace InstaConnect.Follows.Application.Tests.Features.Follows.Assertions;

public static class FollowExceptionAssertions
{
    extension(IApplicationSender sender)
    {
        public async Task ShouldThrowFollowingNotFoundExceptionAsync(
        GetAllFollowsForFollowingQueryRequest request,
        CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNotFoundExceptionAsync<GetAllFollowsForFollowingQueryRequest, GetAllFollowsForFollowingQueryResponse>(
                r => r.FollowingId,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowFollowingNotFoundExceptionAsync(
            AddFollowCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNotFoundExceptionAsync<AddFollowCommandRequest, AddFollowCommandResponse>(
                r => r.FollowingId,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowFollowerNotFoundExceptionAsync(
            AddFollowCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNotFoundExceptionAsync<AddFollowCommandRequest, AddFollowCommandResponse>(
                r => r.FollowerId,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowFollowerNotFoundExceptionAsync(
            DeleteFollowCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNotFoundExceptionAsync(
                r => r.FollowerId,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowFollowerNotFoundExceptionAsync(
            GetFollowByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNotFoundExceptionAsync<GetFollowByIdQueryRequest, GetFollowByIdQueryResponse>(
                r => r.FollowerId,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowFollowerNotFoundExceptionAsync(
            GetAllFollowsQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNotFoundExceptionAsync<GetAllFollowsQueryRequest, GetAllFollowsQueryResponse>(
                r => r.FollowerId,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowFollowNotFoundExceptionAsync(
            DeleteFollowCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowFollowNotFoundExceptionAsync(
                r => r.FollowerId,
                r => r.FollowingId,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowFollowNotFoundExceptionAsync(
            GetFollowByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowFollowNotFoundExceptionAsync<GetFollowByIdQueryRequest, GetFollowByIdQueryResponse>(
                r => r.FollowerId,
                r => r.FollowingId,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowFollowAlreadyExistsExceptionAsync(
            AddFollowCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowFollowAlreadyExistsExceptionAsync<AddFollowCommandRequest, AddFollowCommandResponse>(
                r => r.FollowerId,
                r => r.FollowingId,
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowFollowNotFoundExceptionAsync<TRequest>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, string> userIdPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest
        {
            await sender.ShouldThrowAsync<FollowNotFoundException, TRequest>(
                FollowExceptionErrorMessages.GetNotFoundMessage(
                new(
                    new(idPropertyExpression(request)),
                    new(userIdPropertyExpression(request)))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowFollowNotFoundExceptionAsync<TRequest, TResponse>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, string> userIdPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest<TResponse>
        {
            await sender.ShouldThrowAsync<FollowNotFoundException, TRequest, TResponse>(
                FollowExceptionErrorMessages.GetNotFoundMessage(
                new(
                    new(idPropertyExpression(request)),
                    new(userIdPropertyExpression(request)))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowFollowAlreadyExistsExceptionAsync<TRequest>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, string> userIdPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest
        {
            await sender.ShouldThrowAsync<FollowAlreadyExistsException, TRequest>(
                FollowExceptionErrorMessages.GetAlreadyExistsMessage(
                new(
                    new(idPropertyExpression(request)),
                    new(userIdPropertyExpression(request)))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowFollowAlreadyExistsExceptionAsync<TRequest, TResponse>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, string> userIdPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest<TResponse>
        {
            await sender.ShouldThrowAsync<FollowAlreadyExistsException, TRequest, TResponse>(
                FollowExceptionErrorMessages.GetAlreadyExistsMessage(
                new(
                    new(idPropertyExpression(request)),
                    new(userIdPropertyExpression(request)))),
                request,
                cancellationToken);
        }
    }
}
