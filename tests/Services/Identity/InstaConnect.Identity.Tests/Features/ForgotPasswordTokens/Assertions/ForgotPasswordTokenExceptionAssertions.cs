using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Exceptions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenExceptionAssertions
{
	extension(Func<Task> func)
	{
		public async Task ShouldThrowForgotPasswordTokenNotFoundExceptionAsync<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> valueropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<ForgotPasswordTokenNotFoundException>(
				ForgotPasswordTokenExceptionErrorMessages.GetNotFoundMessage(
					new(
						new(idPropertyExpression(request)),
						valueropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowForgotPasswordTokenNotFoundExceptionAsync<TRequest>(
			Func<TRequest, ForgotPasswordTokenId> idPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<ForgotPasswordTokenNotFoundException>(
				ForgotPasswordTokenExceptionErrorMessages.GetNotFoundMessage(idPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowForgotPasswordTokenExpiredExceptionAsync<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> valuePropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<ForgotPasswordTokenExpiredException>(
				ForgotPasswordTokenExceptionErrorMessages.GetExpiredMessage(
					new(
						new(idPropertyExpression(request)),
						valuePropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowForgotPasswordTokenExpiredExceptionAsync<TRequest>(
			Func<TRequest, ForgotPasswordTokenId> idPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<ForgotPasswordTokenExpiredException>(
				ForgotPasswordTokenExceptionErrorMessages.GetExpiredMessage(idPropertyExpression(request)),
				cancellationToken);
		}
	}
}
