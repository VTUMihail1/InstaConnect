using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Exceptions;

using MediatR;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Assertions;

public static class PostExceptionAssertions
{
    extension(IApplicationSender sender)
    {
        public async Task ShouldThrowUserNotFoundExceptionAsync(
        GetAllPostsForUserQueryRequest request,
        CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNotFoundExceptionAsync<GetAllPostsForUserQueryRequest, GetAllPostsForUserQueryResponse>(
                r => r.UserId,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowUserNotFoundExceptionAsync(
            AddPostCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNotFoundExceptionAsync<AddPostCommandRequest, AddPostCommandResponse>(
                r => r.UserId,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowPostNotFoundExceptionAsync(
            UpdatePostCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowPostNotFoundExceptionAsync<UpdatePostCommandRequest, UpdatePostCommandResponse>(
                r => r.Id,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowPostNotFoundExceptionAsync(
            GetPostByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowPostNotFoundExceptionAsync<GetPostByIdQueryRequest, GetPostByIdQueryResponse>(
                r => r.Id,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowPostNotFoundExceptionAsync(
            DeletePostCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowPostNotFoundExceptionAsync(
                r => r.Id,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowPostForbiddenExceptionAsync(
            UpdatePostCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowPostForbiddenExceptionAsync<UpdatePostCommandRequest, UpdatePostCommandResponse>(
                r => r.Id,
                r => r.UserId,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowPostForbiddenExceptionAsync(
            DeletePostCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowPostForbiddenExceptionAsync(
                r => r.Id,
                r => r.UserId,
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowPostNotFoundExceptionAsync<TRequest>(
            Func<TRequest, string> idPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest
        {
            await sender.ShouldThrowAsync<PostNotFoundException, TRequest>(
                PostExceptionErrorMessages.GetNotFoundMessage(new(idPropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowPostNotFoundExceptionAsync<TRequest, TResponse>(
            Func<TRequest, string> idPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest<TResponse>
        {
            await sender.ShouldThrowAsync<PostNotFoundException, TRequest, TResponse>(
                PostExceptionErrorMessages.GetNotFoundMessage(new(idPropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowPostForbiddenExceptionAsync<TRequest>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, string> userIdPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest
        {
            await sender.ShouldThrowAsync<PostForbiddenException, TRequest>(
                PostExceptionErrorMessages.GetForbiddenMessage(new(idPropertyExpression(request)), new(userIdPropertyExpression(request))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowPostForbiddenExceptionAsync<TRequest, TResponse>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, string> userIdPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest<TResponse>
        {
            await sender.ShouldThrowAsync<PostForbiddenException, TRequest, TResponse>(
                PostExceptionErrorMessages.GetForbiddenMessage(new(idPropertyExpression(request)), new(userIdPropertyExpression(request))),
                request,
                cancellationToken);
        }
    }
}
