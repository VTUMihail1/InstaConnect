using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;

namespace InstaConnect.Follows.Presentation.Tests.Features.Users.Assertions;

public static class UserProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		internal void ShouldSatisfyUserNotFound<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			TRequest request)
		{
			problemDetails.ShouldSatisfyNotFound(
				UserExceptionErrorMessages.GetNotFoundMessage(new(idPropertyExpression(request))));
		}

		internal void ShouldSatisfyUserAlreadyExists<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			TRequest request)
		{
			problemDetails.ShouldSatisfyBadRequest(
				UserExceptionErrorMessages.GetAlreadyExistsMessage(new(idPropertyExpression(request))));
		}

		internal void ShouldSatisfyUserNameAlreadyExists<TRequest>(
			Func<TRequest, string> namePropertyExpression,
			TRequest request)
		{
			problemDetails.ShouldSatisfyBadRequest(
				UserExceptionErrorMessages.GetNameAlreadyExistsMessage(new(namePropertyExpression(request))));
		}

		internal void ShouldSatisfyUserEmailAlreadyExists<TRequest>(
			Func<TRequest, string> emailPropertyExpression,
			TRequest request)
		{
			problemDetails.ShouldSatisfyBadRequest(
				UserExceptionErrorMessages.GetEmailAlreadyExistsMessage(new(emailPropertyExpression(request))));
		}
	}
}
