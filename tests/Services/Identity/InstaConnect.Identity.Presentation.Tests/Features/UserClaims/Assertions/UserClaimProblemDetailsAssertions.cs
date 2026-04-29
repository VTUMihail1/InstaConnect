using InstaConnect.Common.Events.Features.AccessTokens.Models;
using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Assertions;

public static class UserClaimProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyUserNotFound(
			GetAllUserClaimsApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				r => r.Id,
				request);
		}

		public void ShouldSatisfyUserNotFound(
			AddUserClaimApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				r => r.Id,
				request);
		}

		public void ShouldSatisfyUserNotFound(
			DeleteUserClaimApiRequest request)
		{
			problemDetails.ShouldSatisfyUserNotFound(
				r => r.Id,
				request);
		}

		public void ShouldSatisfyUserClaimAlreadyExists(
			AddUserClaimApiRequest request)
		{
			problemDetails.ShouldSatisfyUserClaimAlreadyExists(
				r => r.Id,
				r => r.Body.Claim,
				request);
		}

		public void ShouldSatisfyUserClaimNotFound(
			DeleteUserClaimApiRequest request)
		{
			problemDetails.ShouldSatisfyUserClaimNotFound(
				r => r.Id,
				r => r.Claim,
				request);
		}

		internal void ShouldSatisfyUserClaimNotFound<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, ApplicationClaims> claimPropertyExpression,
			TRequest request)
		{
			problemDetails.ShouldSatisfyNotFound(
				UserClaimExceptionErrorMessages.GetNotFoundMessage(new UserClaimId(new UserId(idPropertyExpression(request)), claimPropertyExpression(request))));
		}

		internal void ShouldSatisfyUserClaimAlreadyExists<TRequest>(
			Func<TRequest, string> idPropertyExpression,
			Func<TRequest, ApplicationClaims> claimPropertyExpression,
			TRequest request)
		{
			problemDetails.ShouldSatisfyBadRequest(
				UserClaimExceptionErrorMessages.GetAlreadyExistsMessage(new UserClaimId(new UserId(idPropertyExpression(request)), claimPropertyExpression(request))));
		}
	}
}
