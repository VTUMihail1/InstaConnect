using InstaConnect.Posts.Domain.Features.PostCommentLikes.Exceptions;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeExceptionAssertions
{
	extension(Func<Task> action)
	{
		public async Task ShouldThrowPostCommentLikeNotFoundExceptionAsync<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> commentIdPropertyExpression,
			Func<TRequest, string> userIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<PostCommentLikeNotFoundException>(
				PostCommentLikeExceptionErrorMessages.GetNotFoundMessage(
					new(
						new(
							new(idPropertyExpression(request)),
							commentIdPropertyExpression(request)),
						new(userIdPropertyExpression(request)))),
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentLikeNotFoundExceptionAsync<TRequest>(
			Func<TRequest, PostCommentLikeId> idPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<PostCommentLikeNotFoundException>(
				PostCommentLikeExceptionErrorMessages.GetNotFoundMessage(idPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> commentIdPropertyExpression,
			Func<TRequest, string> userIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<PostCommentLikeAlreadyExistsException>(
				PostCommentLikeExceptionErrorMessages.GetAlreadyExistsMessage(
					new(
						new(
							new(idPropertyExpression(request)),
							commentIdPropertyExpression(request)),
						new(userIdPropertyExpression(request)))),
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync<TRequest>(
			Func<TRequest, PostCommentLikeId> idPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<PostCommentLikeAlreadyExistsException>(
				PostCommentLikeExceptionErrorMessages.GetAlreadyExistsMessage(idPropertyExpression(request)),
				cancellationToken);
		}
	}
}
