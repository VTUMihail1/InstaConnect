using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Assertions;

public static class FollowProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyFollowingNotFound(
		AddFollowApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				r => r.Body.FollowingId,
				request);
		}

		public void ShouldSatisfyFollowingNotFound(
			GetAllFollowsForFollowingApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				r => r.FollowingId,
				request);
		}

		public void ShouldSatisfyFollowerNotFound(
			AddFollowApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				r => r.FollowerId,
				request);
		}

		public void ShouldSatisfyFollowerNotFound(
			DeleteFollowApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				r => r.FollowerId,
				request);
		}

		public void ShouldSatisfyFollowerNotFound(
			GetFollowByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				r => r.FollowerId,
				request);
		}

		public void ShouldSatisfyFollowerNotFound(
			GetAllFollowsApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				r => r.FollowerId,
				request);
		}

		public void ShouldSatisfyFollowNotFound(
			DeleteFollowApiRequest request)
		{
			problemDetails.ShouldSatisfyFollowNotFound(
				r => r.FollowerId,
				r => r.FollowingId,
				request);
		}

		public void ShouldSatisfyFollowNotFound(
			GetFollowByIdApiRequest request)
		{
			problemDetails.ShouldSatisfyFollowNotFound(
				r => r.FollowerId,
				r => r.FollowingId,
				request);
		}

		public void ShouldSatisfyFollowAlreadyExists(
			AddFollowApiRequest request)
		{
			problemDetails.ShouldSatisfyFollowAlreadyExists(
				r => r.FollowerId,
				r => r.Body.FollowingId,
				request);
		}

		internal void ShouldSatisfyFollowNotFound<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> userIdPropertyExpression,
			TRequest request)
		{
			problemDetails.ShouldSatisfyNotFound(
				FollowExceptionErrorMessages.GetNotFoundMessage(
					new(
						new(idPropertyExpression(request)),
						new(userIdPropertyExpression(request)))));
		}

		internal void ShouldSatisfyFollowAlreadyExists<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> userIdPropertyExpression,
			TRequest request)
		{
			problemDetails.ShouldSatisfyBadRequest(
				FollowExceptionErrorMessages.GetAlreadyExistsMessage(
					new(
						new(idPropertyExpression(request)),
						new(userIdPropertyExpression(request)))));
		}
	}
}
