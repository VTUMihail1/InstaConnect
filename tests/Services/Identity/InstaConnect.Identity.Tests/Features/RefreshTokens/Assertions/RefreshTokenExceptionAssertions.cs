using InstaConnect.Identity.Domain.Features.RefreshTokens.Exceptions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenExceptionAssertions
{
	extension(Func<Task> action)
	{
		public async Task ShouldThrowRefreshTokenNotFoundExceptionAsync<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> valueropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<RefreshTokenNotFoundException>(
				RefreshTokenExceptionErrorMessages.GetNotFoundMessage(
					new(
						new(idPropertyExpression(request)),
						valueropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowRefreshTokenNotFoundExceptionAsync<TRequest>(
			Func<TRequest, RefreshTokenId> idPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<RefreshTokenNotFoundException>(
				RefreshTokenExceptionErrorMessages.GetNotFoundMessage(idPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowRefreshTokenExpiredExceptionAsync<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, string> valuePropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<RefreshTokenExpiredException>(
				RefreshTokenExceptionErrorMessages.GetExpiredMessage(
					new(
						new(idPropertyExpression(request)),
						valuePropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowRefreshTokenExpiredExceptionAsync<TRequest>(
			Func<TRequest, RefreshTokenId> idPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await action.ShouldThrowAsync<RefreshTokenExpiredException>(
				RefreshTokenExceptionErrorMessages.GetExpiredMessage(idPropertyExpression(request)),
				cancellationToken);
		}
	}
}
