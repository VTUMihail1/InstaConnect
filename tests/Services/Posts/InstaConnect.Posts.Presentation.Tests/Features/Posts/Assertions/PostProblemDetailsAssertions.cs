using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Assertions;

public static class PostProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyUserNotFound(
		AddPostApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				r => r.UserId,
				request);
		}

		public void ShouldSatisfyUserNotFound(
			GetAllPostsForUserApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				r => r.UserId,
				request);
		}

		public void ShouldSatisfyPostNotFound(
			UpdatePostApiRequest request)
		{
			problemDetails.ShouldSatisfyPostNotFound(
				r => r.Id,
				request);
		}

		public void ShouldSatisfyPostNotFound(
			GetPostByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyPostNotFound(
				r => r.Id,
				request);
		}

		public void ShouldSatisfyPostNotFound(
			DeletePostApiRequest request)
		{
			problemDetails.ShouldSatisfyPostNotFound(
				r => r.Id,
				request);
		}

		public void ShouldSatisfyPostForbidden(
			UpdatePostApiRequest request)
		{
			problemDetails.ShouldSatisfyPostForbidden(
				r => r.Id,
				r => r.UserId,
				request);
		}

		public void ShouldSatisfyPostForbidden(
			DeletePostApiRequest request)
		{
			problemDetails.ShouldSatisfyPostForbidden(
				r => r.Id,
				r => r.UserId,
				request);
		}

		internal void ShouldSatisfyPostNotFound<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			TRequest request)
		{
			problemDetails.ShouldSatisfyNotFound(
				PostExceptionErrorMessages.GetNotFoundMessage(new(idPropertyExpression(request))));
		}

		internal void ShouldSatisfyPostForbidden<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> userIdPropertyExpression,
			TRequest request)
		{
			problemDetails.ShouldSatisfyForbidden(
				PostExceptionErrorMessages.GetForbiddenMessage(
					new(idPropertyExpression(request)),
					new(userIdPropertyExpression(request))));
		}
	}
}
