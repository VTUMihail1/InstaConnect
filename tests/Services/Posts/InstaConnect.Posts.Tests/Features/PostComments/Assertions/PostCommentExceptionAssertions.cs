using InstaConnect.Posts.Domain.Features.PostComments.Exceptions;
using InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.Users.Models.ValueObjects;

namespace InstaConnect.Posts.Tests.Features.PostComments.Assertions;

public static class PostCommentExceptionAssertions
{
	extension(Func<Task> action)
	{
		public async Task ShouldThrowPostCommentNotFoundExceptionAsync<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> commentIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<PostCommentNotFoundException>(
				PostCommentExceptionErrorMessages.GetNotFoundMessage(
					new(
						new(idPropertyExpression(request)),
						new(commentIdPropertyExpression(request)))),
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentNotFoundExceptionAsync<TRequest>(
			Func<TRequest, PostCommentId> commentIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<PostCommentNotFoundException>(
				PostCommentExceptionErrorMessages.GetNotFoundMessage(commentIdPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentForbiddenExceptionAsync<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> commentIdPropertyExpression,
			Func<TRequest, string> userIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<PostCommentForbiddenException>(
				PostCommentExceptionErrorMessages.GetForbiddenMessage(
					new(
						new(idPropertyExpression(request)),
						new(commentIdPropertyExpression(request))),
					new(userIdPropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowPostCommentForbiddenExceptionAsync<TRequest>(
			Func<TRequest, PostCommentId> commentIdPropertyExpression,
			Func<TRequest, UserId> userIdPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<PostCommentForbiddenException>(
				PostCommentExceptionErrorMessages.GetForbiddenMessage(
					commentIdPropertyExpression(request),
					userIdPropertyExpression(request)),
				cancellationToken);
		}
	}
}
