using InstaConnect.Common.Domain.Utilities;

namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Assertions;

public static class UserClaimValidationAssertions
{
    extension(TestValidationResult<DeleteUserClaimCommandRequest> result)
    {
        public void ShouldHaveValidationErrorForId(
            IStringMessageTransformer messageTransformer,
            DeleteUserClaimCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForClaim(
            IEnumMessageTransformer<ApplicationClaims> messageTransformer,
            DeleteUserClaimCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Claim, messageTransformer, request);
        }
    }

    extension(TestValidationResult<AddUserClaimCommandRequest> result)
    {
        public void ShouldHaveValidationErrorForId(
            IStringMessageTransformer messageTransformer,
            AddUserClaimCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForClaim(
            IEnumMessageTransformer<ApplicationClaims> messageTransformer,
            AddUserClaimCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Claim, messageTransformer, request);
        }
    }

    extension(TestValidationResult<GetAllUserClaimsQueryRequest> result)
    {
        public void ShouldHaveValidationErrorForId(
            IStringMessageTransformer messageTransformer,
            GetAllUserClaimsQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForCurrentId(
            IStringMessageTransformer messageTransformer,
            GetAllUserClaimsQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.CurrentId, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForPage(
            IIntMessageTransformer messageTransformer,
            GetAllUserClaimsQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Page, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForPageSize(
            IIntMessageTransformer messageTransformer,
            GetAllUserClaimsQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.PageSize, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForSortOrder(
            IEnumMessageTransformer<CommonSortOrder> messageTransformer,
            GetAllUserClaimsQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.SortOrder, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForSortTerm(
            IEnumMessageTransformer<UserClaimsSortTerm> messageTransformer,
            GetAllUserClaimsQueryRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.SortTerm, messageTransformer, request);
        }
    }
}
