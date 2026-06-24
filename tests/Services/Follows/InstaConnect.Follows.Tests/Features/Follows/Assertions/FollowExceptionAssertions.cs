using InstaConnect.Follows.Domain.Features.Follows.Exceptions;
using InstaConnect.Follows.Domain.Features.Follows.Models.ValueObjects;

namespace InstaConnect.Follows.Tests.Features.Follows.Assertions;

public static class FollowExceptionAssertions
{
	extension(Func<Task> func)
	{
		public async Task ShouldThrowFollowNotFoundExceptionAsync<TRequest>(
			Func<TRequest, string> followerIdPropertyExpression,
			Func<TRequest, string> followingIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<FollowNotFoundException>(
				FollowExceptionErrorMessages.GetNotFoundMessage(
				new(
					new(followerIdPropertyExpression(request)),
					new(followingIdPropertyExpression(request)))),
				cancellationToken);
		}

		public async Task ShouldThrowFollowNotFoundExceptionAsync<TRequest>(
			Func<TRequest, FollowId> idPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<FollowNotFoundException>(
				FollowExceptionErrorMessages.GetNotFoundMessage(idPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowFollowAlreadyExistsExceptionAsync<TRequest>(
			Func<TRequest, string> followerIdPropertyExpression,
			Func<TRequest, string> followingIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<FollowAlreadyExistsException>(
				FollowExceptionErrorMessages.GetAlreadyExistsMessage(
				new(
					new(followerIdPropertyExpression(request)),
					new(followingIdPropertyExpression(request)))),
				cancellationToken);
		}

		public async Task ShouldThrowFollowAlreadyExistsExceptionAsync<TRequest>(
			Func<TRequest, FollowId> idPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<FollowAlreadyExistsException>(
				FollowExceptionErrorMessages.GetAlreadyExistsMessage(idPropertyExpression(request)),
				cancellationToken);
		}
	}
}
