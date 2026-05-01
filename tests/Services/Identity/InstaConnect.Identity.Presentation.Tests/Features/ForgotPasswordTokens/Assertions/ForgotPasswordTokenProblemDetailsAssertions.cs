using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;

namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyUserNameNotFound(
			AddForgotPasswordTokenApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNameNotFound(
				r => r.Name,
				request);
		}

		public void ShouldSatisfyUserNotFound(
			VerifyForgotPasswordTokenApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				r => r.Id,
				request);
		}

		public void ShouldSatisfyForgotPasswordTokenNotFound(
			VerifyForgotPasswordTokenApiRequest request)
		{
			problemDetails.ShouldSatisfyForgotPasswordTokenNotFound(
				r => r.Id,
				r => r.Value,
				request);
		}

		public void ShouldSatisfyForgotPasswordTokenExpired(
			VerifyForgotPasswordTokenApiRequest request)
		{
			problemDetails.ShouldSatisfyForgotPasswordTokenExpired(
				r => r.Id,
				r => r.Value,
				request);
		}

		internal void ShouldSatisfyForgotPasswordTokenNotFound<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> valuePropertyExpression,
			TRequest request)
		{
			problemDetails.ShouldSatisfyNotFound(
				ForgotPasswordTokenExceptionErrorMessages.GetNotFoundMessage(
					new ForgotPasswordTokenId(
						new UserId(idPropertyExpression(request)),
						valuePropertyExpression(request))));
		}

		internal void ShouldSatisfyForgotPasswordTokenExpired<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> valuePropertyExpression,
			TRequest request)
		{
			problemDetails.ShouldSatisfyBadRequest(
				ForgotPasswordTokenExceptionErrorMessages.GetExpiredMessage(
					new ForgotPasswordTokenId(
						new UserId(idPropertyExpression(request)),
						valuePropertyExpression(request))));
		}
	}
}
