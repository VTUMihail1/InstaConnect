using InstaConnect.Posts.Domain.Features.PostLikes.Exceptions;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Assertions;

public static class PostLikeExceptionAssertions
{
	extension(Func<Task> action)
	{
		public async Task ShouldThrowPostLikeNotFoundExceptionAsync<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> userIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<PostLikeNotFoundException>(
				PostLikeExceptionErrorMessages.GetNotFoundMessage(
				new(
					new(idPropertyExpression(request)),
					new(userIdPropertyExpression(request)))),
				cancellationToken);
		}

		public async Task ShouldThrowPostLikeNotFoundExceptionAsync<TRequest>(
			Func<TRequest, PostLikeId> likeIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<PostLikeNotFoundException>(
				PostLikeExceptionErrorMessages.GetNotFoundMessage(likeIdPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowPostLikeAlreadyExistsExceptionAsync<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> userIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<PostLikeAlreadyExistsException>(
				PostLikeExceptionErrorMessages.GetAlreadyExistsMessage(
				new(
					new(idPropertyExpression(request)),
					new(userIdPropertyExpression(request)))),
				cancellationToken);
		}

		public async Task ShouldThrowPostLikeAlreadyExistsExceptionAsync<TRequest>(
			Func<TRequest, PostLikeId> likeIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<PostLikeAlreadyExistsException>(
				PostLikeExceptionErrorMessages.GetAlreadyExistsMessage(likeIdPropertyExpression(request)),
				cancellationToken);
		}
	}
}
