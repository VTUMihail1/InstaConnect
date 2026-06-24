using InstaConnect.Posts.Domain.Features.PostComments.Exceptions;
using InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.Users.Models.ValueObjects;

namespace InstaConnect.Posts.Tests.Features.PostComments.Assertions;

public static class PostCommentExceptionAssertions
{
	extension(Func<Task> func)
	{
		public async Task ShouldThrowPostCommentNotFoundExceptionAsync<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> commentIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<PostCommentNotFoundException>(
				PostCommentExceptionErrorMessages.GetNotFoundMessage(
					new(
						new(idPropertyExpression(request)),
						new(commentIdPropertyExpression(request)))),
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentNotFoundExceptionAsync<TRequest>(
			Func<TRequest, PostCommentId> idPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<PostCommentNotFoundException>(
				PostCommentExceptionErrorMessages.GetNotFoundMessage(idPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentForbiddenExceptionAsync<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> commentIdPropertyExpression,
			Func<TRequest, string> userIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<PostCommentForbiddenException>(
				PostCommentExceptionErrorMessages.GetForbiddenMessage(
					new(
						new(idPropertyExpression(request)),
						new(commentIdPropertyExpression(request))),
					new(userIdPropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentForbiddenExceptionAsync<TRequest>(
			Func<TRequest, PostCommentId> idPropertyExpression,
			Func<TRequest, UserId> userIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<PostCommentForbiddenException>(
				PostCommentExceptionErrorMessages.GetForbiddenMessage(
					idPropertyExpression(request),
					userIdPropertyExpression(request)),
				cancellationToken);
		}
	}
}
