using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Posts.Domain.Features.PostComments.Exceptions;

using MediatR;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Assertions;

public static class PostCommentExceptionAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
			AddPostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowUserNotFoundExceptionAsync<AddPostCommentCommandRequest, AddPostCommentCommandResponse>(
				r => r.UserId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			GetAllPostCommentsForUserQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowUserNotFoundExceptionAsync<GetAllPostCommentsForUserQueryRequest, GetAllPostCommentsForUserQueryResponse>(
				r => r.UserId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			AddPostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowPostNotFoundExceptionAsync<AddPostCommentCommandRequest, AddPostCommentCommandResponse>(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			UpdatePostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowPostNotFoundExceptionAsync<UpdatePostCommentCommandRequest, UpdatePostCommentCommandResponse>(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			DeletePostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowPostNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			GetPostCommentByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowPostNotFoundExceptionAsync<GetPostCommentByIdQueryRequest, GetPostCommentByIdQueryResponse>(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			GetAllPostCommentsQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowPostNotFoundExceptionAsync<GetAllPostCommentsQueryRequest, GetAllPostCommentsQueryResponse>(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentNotFoundExceptionAsync(
			UpdatePostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowPostCommentNotFoundExceptionAsync<UpdatePostCommentCommandRequest, UpdatePostCommentCommandResponse>(
				r => r.Id,
				r => r.CommentId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentNotFoundExceptionAsync(
			DeletePostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowPostCommentNotFoundExceptionAsync(
				r => r.Id,
				r => r.CommentId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentNotFoundExceptionAsync(
			GetPostCommentByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowPostCommentNotFoundExceptionAsync<GetPostCommentByIdQueryRequest, GetPostCommentByIdQueryResponse>(
				r => r.Id,
				r => r.CommentId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentForbiddenExceptionAsync(
			DeletePostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowPostCommentForbiddenExceptionAsync(
				r => r.Id,
				r => r.CommentId,
				r => r.UserId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentForbiddenExceptionAsync(
			UpdatePostCommentCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowPostCommentForbiddenExceptionAsync<UpdatePostCommentCommandRequest, UpdatePostCommentCommandResponse>(
				r => r.Id,
				r => r.CommentId,
				r => r.UserId,
				request,
				cancellationToken);
		}

		internal async Task ShouldThrowPostCommentNotFoundExceptionAsync<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> commentIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
			where TRequest : IRequest
		{
			await sender.ShouldThrowAsync<PostCommentNotFoundException, TRequest>(
				PostCommentExceptionErrorMessages.GetNotFoundMessage(
					new(
						new(idPropertyExpression(request)),
						new(commentIdPropertyExpression(request)))),
				request,
				cancellationToken);
		}

		internal async Task ShouldThrowPostCommentNotFoundExceptionAsync<TRequest, TResponse>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> commentIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
			where TRequest : IRequest<TResponse>
		{
			await sender.ShouldThrowAsync<PostCommentNotFoundException, TRequest, TResponse>(
				PostCommentExceptionErrorMessages.GetNotFoundMessage(
					new(
						new(idPropertyExpression(request)),
						new(commentIdPropertyExpression(request)))),
				request,
				cancellationToken);
		}

		internal async Task ShouldThrowPostCommentForbiddenExceptionAsync<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> commentIdPropertyExpression,
			Func<TRequest, string> userIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
			where TRequest : IRequest
		{
			await sender.ShouldThrowAsync<PostCommentForbiddenException, TRequest>(
				PostCommentExceptionErrorMessages.GetForbiddenMessage(
					new(
						new(idPropertyExpression(request)),
						new(commentIdPropertyExpression(request))),
					new(userIdPropertyExpression(request))),
				request,
				cancellationToken);
		}

		internal async Task ShouldThrowPostCommentForbiddenExceptionAsync<TRequest, TResponse>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> commentIdPropertyExpression,
			Func<TRequest, string> userIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
			where TRequest : IRequest<TResponse>
		{
			await sender.ShouldThrowAsync<PostCommentForbiddenException, TRequest, TResponse>(
				PostCommentExceptionErrorMessages.GetForbiddenMessage(
					new(
						new(idPropertyExpression(request)),
						new(commentIdPropertyExpression(request))),
					new(userIdPropertyExpression(request))),
				request,
				cancellationToken);
		}
	}
}
