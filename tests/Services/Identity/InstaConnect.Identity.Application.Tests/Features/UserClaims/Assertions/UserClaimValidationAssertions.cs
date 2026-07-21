using InstaConnect.Common.Domain.Features.Messaging.Models;
using InstaConnect.Common.Events.Features.AccessTokens.Models;

namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Assertions;

public static class UserClaimValidationAssertions
{
	extension(TestValidationResult<DeleteUserClaimCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			IStringMessageTransformer messageTransformer,
			DeleteUserClaimCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForClaim(
			IEnumMessageTransformer<ApplicationClaims> messageTransformer,
			DeleteUserClaimCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Claim, messageTransformer);
		}
	}

	extension(TestValidationResult<AddUserClaimCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			IStringMessageTransformer messageTransformer,
			AddUserClaimCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForClaim(
			IEnumMessageTransformer<ApplicationClaims> messageTransformer,
			AddUserClaimCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Claim, messageTransformer);
		}
	}

	extension(TestValidationResult<GetAllUserClaimsQueryRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			IStringMessageTransformer messageTransformer,
			GetAllUserClaimsQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentId(
			IStringMessageTransformer messageTransformer,
			GetAllUserClaimsQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.CurrentId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPage(
			IIntMessageTransformer messageTransformer,
			GetAllUserClaimsQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Page, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPageSize(
			IIntMessageTransformer messageTransformer,
			GetAllUserClaimsQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.PageSize, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortOrder(
			IEnumMessageTransformer<CommonSortOrder> messageTransformer,
			GetAllUserClaimsQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.SortOrder, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortTerm(
			IEnumMessageTransformer<UserClaimsSortTerm> messageTransformer,
			GetAllUserClaimsQueryRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.SortTerm, messageTransformer);
		}
	}
}
