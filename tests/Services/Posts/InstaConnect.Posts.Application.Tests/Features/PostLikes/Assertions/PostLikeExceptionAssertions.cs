using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Posts.Domain.Features.PostLikes.Exceptions;

using MediatR;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Assertions;

public static class PostLikeExceptionAssertions
{
	extension(IApplicationSender sender)
	{
		public async Task ShouldThrowUserNotFoundExceptionAsync(
		GetAllPostLikesForUserQueryRequest request,
		CancellationToken cancellationToken)
		{
			await sender.ShouldThrowUserNotFoundExceptionAsync<GetAllPostLikesForUserQueryRequest, GetAllPostLikesForUserQueryResponse>(
				r => r.UserId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowUserNotFoundExceptionAsync(
			AddPostLikeCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowUserNotFoundExceptionAsync<AddPostLikeCommandRequest, AddPostLikeCommandResponse>(
				r => r.UserId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			AddPostLikeCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowPostNotFoundExceptionAsync<AddPostLikeCommandRequest, AddPostLikeCommandResponse>(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			DeletePostLikeCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowPostNotFoundExceptionAsync(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			GetPostLikeByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowPostNotFoundExceptionAsync<GetPostLikeByIdQueryRequest, GetPostLikeByIdQueryResponse>(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostNotFoundExceptionAsync(
			GetAllPostLikesQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowPostNotFoundExceptionAsync<GetAllPostLikesQueryRequest, GetAllPostLikesQueryResponse>(
				r => r.Id,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostLikeNotFoundExceptionAsync(
			DeletePostLikeCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowPostLikeNotFoundExceptionAsync(
				r => r.Id,
				r => r.UserId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostLikeNotFoundExceptionAsync(
			GetPostLikeByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowPostLikeNotFoundExceptionAsync<GetPostLikeByIdQueryRequest, GetPostLikeByIdQueryResponse>(
				r => r.Id,
				r => r.UserId,
				request,
				cancellationToken);
		}

		public async Task ShouldThrowPostLikeAlreadyExistsExceptionAsync(
			AddPostLikeCommandRequest request,
			CancellationToken cancellationToken)
		{
			await sender.ShouldThrowPostLikeAlreadyExistsExceptionAsync<AddPostLikeCommandRequest, AddPostLikeCommandResponse>(
				r => r.Id,
				r => r.UserId,
				request,
				cancellationToken);
		}

		internal async Task ShouldThrowPostLikeNotFoundExceptionAsync<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> userIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
			where TRequest : IRequest
		{
			await sender.ShouldThrowAsync<PostLikeNotFoundException, TRequest>(
				PostLikeExceptionErrorMessages.GetNotFoundMessage(
				new(
					new(idPropertyExpression(request)),
					new(userIdPropertyExpression(request)))),
				request,
				cancellationToken);
		}

		internal async Task ShouldThrowPostLikeNotFoundExceptionAsync<TRequest, TResponse>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> userIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
			where TRequest : IRequest<TResponse>
		{
			await sender.ShouldThrowAsync<PostLikeNotFoundException, TRequest, TResponse>(
				PostLikeExceptionErrorMessages.GetNotFoundMessage(
				new(
					new(idPropertyExpression(request)),
					new(userIdPropertyExpression(request)))),
				request,
				cancellationToken);
		}

		internal async Task ShouldThrowPostLikeAlreadyExistsExceptionAsync<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> userIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
			where TRequest : IRequest
		{
			await sender.ShouldThrowAsync<PostLikeAlreadyExistsException, TRequest>(
				PostLikeExceptionErrorMessages.GetAlreadyExistsMessage(
				new(
					new(idPropertyExpression(request)),
					new(userIdPropertyExpression(request)))),
				request,
				cancellationToken);
		}

		internal async Task ShouldThrowPostLikeAlreadyExistsExceptionAsync<TRequest, TResponse>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> userIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
			where TRequest : IRequest<TResponse>
		{
			await sender.ShouldThrowAsync<PostLikeAlreadyExistsException, TRequest, TResponse>(
				PostLikeExceptionErrorMessages.GetAlreadyExistsMessage(
				new(
					new(idPropertyExpression(request)),
					new(userIdPropertyExpression(request)))),
				request,
				cancellationToken);
		}
	}
}
