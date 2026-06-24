using InstaConnect.Posts.Domain.Features.Posts.Exceptions;
using InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.Users.Models.ValueObjects;

namespace InstaConnect.Posts.Tests.Features.Posts.Assertions;

public static class PostExceptionAssertions
{
	extension(Func<Task> func)
	{
		public async Task ShouldThrowPostNotFoundExceptionAsync<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<PostNotFoundException>(
				PostExceptionErrorMessages.GetNotFoundMessage(new(idPropertyExpression(request))),
				cancellationToken);
		}
		public async Task ShouldThrowPostNotFoundExceptionAsync<TRequest>(
			Func<TRequest, PostId> idPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<PostNotFoundException>(
				PostExceptionErrorMessages.GetNotFoundMessage(idPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowPostForbiddenExceptionAsync<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> userIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<PostForbiddenException>(
				PostExceptionErrorMessages.GetForbiddenMessage(new(idPropertyExpression(request)), new(userIdPropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowPostForbiddenExceptionAsync<TRequest>(
			Func<TRequest, PostId> idPropertyExpression,
			Func<TRequest, UserId> userIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<PostForbiddenException>(
				PostExceptionErrorMessages.GetForbiddenMessage(idPropertyExpression(request), userIdPropertyExpression(request)),
				cancellationToken);
		}
	}
}
