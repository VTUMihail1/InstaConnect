using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Assertions;

public static class PostCommentProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyUserNotFound(
		AddPostCommentApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				r => r.UserId,
				request);
		}

		public void ShouldSatisfyUserNotFound(
			GetAllPostCommentsForUserApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				r => r.UserId,
				request);
		}

		public void ShouldSatisfyPostNotFound(
			AddPostCommentApiRequest request)
		{
			problemDetails.ShouldSatisfyPostNotFound(
				r => r.Id,
				request);
		}

		public void ShouldSatisfyPostNotFound(
			UpdatePostCommentApiRequest request)
		{
			problemDetails.ShouldSatisfyPostNotFound(
				r => r.Id,
				request);
		}

		public void ShouldSatisfyPostNotFound(
			DeletePostCommentApiRequest request)
		{
			problemDetails.ShouldSatisfyPostNotFound(
				r => r.Id,
				request);
		}

		public void ShouldSatisfyPostNotFound(
			GetPostCommentByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyPostNotFound(
				r => r.Id,
				request);
		}

		public void ShouldSatisfyPostNotFound(
			GetAllPostCommentsApiRequest request)
		{
			problemDetails.ShouldSatisfyPostNotFound(
				r => r.Id,
				request);
		}

		public void ShouldSatisfyPostCommentNotFound(
			UpdatePostCommentApiRequest request)
		{
			problemDetails.ShouldSatisfyPostCommentNotFound(
				r => r.Id,
				r => r.CommentId,
				request);
		}

		public void ShouldSatisfyPostCommentNotFound(
			DeletePostCommentApiRequest request)
		{
			problemDetails.ShouldSatisfyPostCommentNotFound(
				r => r.Id,
				r => r.CommentId,
				request);
		}

		public void ShouldSatisfyPostCommentNotFound(
			GetPostCommentByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyPostCommentNotFound(
				r => r.Id,
				r => r.CommentId,
				request);
		}

		public void ShouldSatisfyPostCommentForbidden(
			DeletePostCommentApiRequest request)
		{
			problemDetails.ShouldSatisfyPostCommentForbidden(
				r => r.Id,
				r => r.CommentId,
				r => r.UserId,
				request);
		}

		public void ShouldSatisfyPostCommentForbidden(
			UpdatePostCommentApiRequest request)
		{
			problemDetails.ShouldSatisfyPostCommentForbidden(
				r => r.Id,
				r => r.CommentId,
				r => r.UserId,
				request);
		}

		internal void ShouldSatisfyPostCommentNotFound<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> commentIdPropertyExpression,
			TRequest request)
		{
			problemDetails.ShouldSatisfyNotFound(
				PostCommentExceptionErrorMessages.GetNotFoundMessage(
					new(
						new(idPropertyExpression(request)),
						new(commentIdPropertyExpression(request)))));
		}

		internal void ShouldSatisfyPostCommentForbidden<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> commentIdPropertyExpression,
			Func<TRequest, string> userIdPropertyExpression,
			TRequest request)
		{
			problemDetails.ShouldSatisfyForbidden(
				PostCommentExceptionErrorMessages.GetForbiddenMessage(
					new(
						new(idPropertyExpression(request)),
						new(commentIdPropertyExpression(request))),
					new(userIdPropertyExpression(request))));
		}
	}
}
