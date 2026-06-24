using InstaConnect.Common.Events.Features.AccessTokens.Models;
using InstaConnect.Identity.Domain.Features.UserClaims.Exceptions;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.ValueObjects;

namespace InstaConnect.Identity.Tests.Features.UserClaims.Assertions;

public static class UserClaimExceptionAssertions
{
	extension(Func<Task> func)
	{
		public async Task ShouldThrowUserClaimNotFoundExceptionAsync<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, ApplicationClaims> claimPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserClaimNotFoundException>(
				UserClaimExceptionErrorMessages.GetNotFoundMessage(
					new(
						new(idPropertyExpression(request)),
						claimPropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowUserClaimNotFoundExceptionAsync<TRequest>(
			Func<TRequest, UserClaimId> idPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserClaimNotFoundException>(
				UserClaimExceptionErrorMessages.GetNotFoundMessage(idPropertyExpression(request)),
				cancellationToken);
		}

		public async Task ShouldThrowUserClaimAlreadyExistsExceptionAsync<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, ApplicationClaims> claimPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserClaimAlreadyExistsException>(
				UserClaimExceptionErrorMessages.GetAlreadyExistsMessage(
					new(
						new(idPropertyExpression(request)),
						claimPropertyExpression(request))),
				cancellationToken);
		}

		public async Task ShouldThrowUserClaimAlreadyExistsExceptionAsync<TRequest>(
			Func<TRequest, UserClaimId> idPropertyExpression,
			TRequest request,
			CancellationToken cancellationToken)
		{
			await func.ShouldThrowAsync<UserClaimAlreadyExistsException>(
				UserClaimExceptionErrorMessages.GetAlreadyExistsMessage(idPropertyExpression(request)),
				cancellationToken);
		}
	}
}
