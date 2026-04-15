using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Exceptions;

using MediatR;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeExceptionAssertions
{
    extension(IApplicationSender sender)
    {
        public async Task ShouldThrowUserNotFoundExceptionAsync(
            AddPostCommentLikeCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNotFoundExceptionAsync<AddPostCommentLikeCommandRequest, AddPostCommentLikeCommandResponse>(
                r => r.UserId,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowUserNotFoundExceptionAsync(
            GetAllPostCommentLikesForUserQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowUserNotFoundExceptionAsync<GetAllPostCommentLikesForUserQueryRequest, GetAllPostCommentLikesForUserQueryResponse>(
                r => r.UserId,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowPostNotFoundExceptionAsync(
            AddPostCommentLikeCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowPostNotFoundExceptionAsync<AddPostCommentLikeCommandRequest, AddPostCommentLikeCommandResponse>(
                r => r.Id,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowPostNotFoundExceptionAsync(
            DeletePostCommentLikeCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowPostNotFoundExceptionAsync(
                r => r.Id,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowPostNotFoundExceptionAsync(
            GetPostCommentLikeByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowPostNotFoundExceptionAsync<GetPostCommentLikeByIdQueryRequest, GetPostCommentLikeByIdQueryResponse>(
                r => r.Id,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowPostNotFoundExceptionAsync(
            GetAllPostCommentLikesQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowPostNotFoundExceptionAsync<GetAllPostCommentLikesQueryRequest, GetAllPostCommentLikesQueryResponse>(
                r => r.Id,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowPostCommentNotFoundExceptionAsync(
            AddPostCommentLikeCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowPostCommentNotFoundExceptionAsync<AddPostCommentLikeCommandRequest, AddPostCommentLikeCommandResponse>(
                r => r.Id,
                r => r.CommentId,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowPostCommentNotFoundExceptionAsync(
            DeletePostCommentLikeCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowPostCommentNotFoundExceptionAsync(
                r => r.Id,
                r => r.CommentId,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowPostCommentNotFoundExceptionAsync(
            GetPostCommentLikeByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowPostCommentNotFoundExceptionAsync<GetPostCommentLikeByIdQueryRequest, GetPostCommentLikeByIdQueryResponse>(
                r => r.Id,
                r => r.CommentId,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowPostCommentNotFoundExceptionAsync(
            GetAllPostCommentLikesQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowPostCommentNotFoundExceptionAsync<GetAllPostCommentLikesQueryRequest, GetAllPostCommentLikesQueryResponse>(
                r => r.Id,
                r => r.CommentId,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowPostCommentLikeNotFoundExceptionAsync(
            DeletePostCommentLikeCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowPostCommentLikeNotFoundExceptionAsync(
                r => r.Id,
                r => r.CommentId,
                r => r.UserId,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowPostCommentLikeNotFoundExceptionAsync(
            GetPostCommentLikeByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowPostCommentLikeNotFoundExceptionAsync<GetPostCommentLikeByIdQueryRequest, GetPostCommentLikeByIdQueryResponse>(
                r => r.Id,
                r => r.CommentId,
                r => r.UserId,
                request,
                cancellationToken);
        }

        public async Task ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(
            AddPostCommentLikeCommandRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync<AddPostCommentLikeCommandRequest, AddPostCommentLikeCommandResponse>(
                r => r.Id,
                r => r.CommentId,
                r => r.UserId,
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowPostCommentLikeNotFoundExceptionAsync<TRequest>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, string> commentIdPropertyExpression,
            Func<TRequest, string> userIdPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest
        {
            await sender.ShouldThrowAsync<PostCommentLikeNotFoundException, TRequest>(
                PostCommentLikeExceptionErrorMessages.GetNotFoundMessage(
                    new(
                        new(
                            new(idPropertyExpression(request)),
                            commentIdPropertyExpression(request)),
                        new(userIdPropertyExpression(request)))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowPostCommentLikeNotFoundExceptionAsync<TRequest, TResponse>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, string> commentIdPropertyExpression,
            Func<TRequest, string> userIdPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest<TResponse>
        {
            await sender.ShouldThrowAsync<PostCommentLikeNotFoundException, TRequest, TResponse>(
                PostCommentLikeExceptionErrorMessages.GetNotFoundMessage(
                    new(
                        new(
                            new(idPropertyExpression(request)),
                            commentIdPropertyExpression(request)),
                        new(userIdPropertyExpression(request)))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync<TRequest>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, string> commentIdPropertyExpression,
            Func<TRequest, string> userIdPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest
        {
            await sender.ShouldThrowAsync<PostCommentLikeAlreadyExistsException, TRequest>(
                PostCommentLikeExceptionErrorMessages.GetAlreadyExistsMessage(
                    new(
                        new(
                            new(idPropertyExpression(request)),
                            commentIdPropertyExpression(request)),
                        new(userIdPropertyExpression(request)))),
                request,
                cancellationToken);
        }

        internal async Task ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync<TRequest, TResponse>(
            Func<TRequest, string> idPropertyExpression,
            Func<TRequest, string> commentIdPropertyExpression,
            Func<TRequest, string> userIdPropertyExpression,
            TRequest request,
            CancellationToken cancellationToken)
            where TRequest : IRequest<TResponse>
        {
            await sender.ShouldThrowAsync<PostCommentLikeAlreadyExistsException, TRequest, TResponse>(
                PostCommentLikeExceptionErrorMessages.GetAlreadyExistsMessage(
                    new(
                        new(
                            new(idPropertyExpression(request)),
                            commentIdPropertyExpression(request)),
                        new(userIdPropertyExpression(request)))),
                request,
                cancellationToken);
        }
    }
}
