using InstaConnect.Common.Events.Models;
using InstaConnect.Common.Presentation.Models;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Assertions;

public static class UserClaimProblemDetailsAssertions
{
    extension(ApplicationProblemDetails problemDetails)
    {
        public void ShouldSatisfyInvalidValidationForId(
            IStringMessageTransformer messageTransformer,
            DeleteUserClaimCommandRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Id,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForId(
            IStringMessageTransformer messageTransformer,
            AddUserClaimCommandRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Id,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForId(
            IStringMessageTransformer messageTransformer,
            GetAllUserClaimsQueryRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Id,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForClaim(
            IEnumMessageTransformer<ApplicationClaims> messageTransformer,
            DeleteUserClaimCommandRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Claim,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForClaim(
            IEnumMessageTransformer<ApplicationClaims> messageTransformer,
            AddUserClaimCommandRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Claim,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForCurrentId(
            IStringMessageTransformer messageTransformer,
            GetAllUserClaimsQueryRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.CurrentId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForPage(
            IIntMessageTransformer messageTransformer,
            GetAllUserClaimsQueryRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Page,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForPageSize(
            IIntMessageTransformer messageTransformer,
            GetAllUserClaimsQueryRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.PageSize,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForSortOrder(
            IEnumMessageTransformer<CommonSortOrder> messageTransformer,
            GetAllUserClaimsQueryRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.SortOrder,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForSortTerm(
            IEnumMessageTransformer<UserClaimsSortTerm> messageTransformer,
            GetAllUserClaimsQueryRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.SortTerm,
                messageTransformer,
                request);
        }
    }
}
