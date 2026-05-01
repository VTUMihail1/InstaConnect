using InstaConnect.Common.Domain.Features.Messaging.Models;
using InstaConnect.Common.Events.Features.AccessTokens.Models;
using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Assertions;

public static class UserClaimValidationProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyInvalidValidationForId(
			IStringMessageTransformer messageTransformer,
			DeleteUserClaimApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Id,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForId(
			IStringMessageTransformer messageTransformer,
			AddUserClaimApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Id,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForId(
			IStringMessageTransformer messageTransformer,
			GetAllUserClaimsApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Id,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForClaim(
			IEnumMessageTransformer<ApplicationClaims> messageTransformer,
			DeleteUserClaimApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Claim,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForClaim(
			IEnumMessageTransformer<ApplicationClaims> messageTransformer,
			AddUserClaimApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Body.Claim,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForCurrentId(
			IStringMessageTransformer messageTransformer,
			GetAllUserClaimsApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.CurrentId,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForPage(
			IIntMessageTransformer messageTransformer,
			GetAllUserClaimsApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Page,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForPageSize(
			IIntMessageTransformer messageTransformer,
			GetAllUserClaimsApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.PageSize,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForSortOrder(
			IEnumMessageTransformer<CommonSortOrder> messageTransformer,
			GetAllUserClaimsApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.SortOrder,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForSortTerm(
			IEnumMessageTransformer<UserClaimsSortTerm> messageTransformer,
			GetAllUserClaimsApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.SortTerm,
				messageTransformer,
				request);
		}
	}
}
