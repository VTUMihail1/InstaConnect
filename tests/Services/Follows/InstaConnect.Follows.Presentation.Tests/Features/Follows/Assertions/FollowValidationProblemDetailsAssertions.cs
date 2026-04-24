using InstaConnect.Common.Domain.Features.Messaging.Models;
using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Assertions;

public static class FollowValidationProblemDetailsAssertions
{
    extension(ApplicationProblemDetails problemDetails)
    {
        public void ShouldSatisfyInvalidValidationForFollowerId(
        IStringMessageTransformer messageTransformer,
        DeleteFollowApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.FollowerId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForFollowerId(
            IStringMessageTransformer messageTransformer,
            GetFollowByIdApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.FollowerId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForFollowerId(
            IStringMessageTransformer messageTransformer,
            AddFollowApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.FollowerId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForFollowerId(
            IStringMessageTransformer messageTransformer,
            GetAllFollowsApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.FollowerId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForCurrentUserId(
            IStringMessageTransformer messageTransformer,
            GetFollowByIdApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.CurrentUserId,
               messageTransformer,
               request);
        }

        public void ShouldSatisfyInvalidValidationForCurrentUserId(
            IStringMessageTransformer messageTransformer,
            GetAllFollowsApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.CurrentUserId,
               messageTransformer,
               request);
        }

        public void ShouldSatisfyInvalidValidationForCurrentUserId(
            IStringMessageTransformer messageTransformer,
            GetAllFollowsForFollowingApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.CurrentUserId,
               messageTransformer,
               request);
        }

        public void ShouldSatisfyInvalidValidationForFollowingId(
            IStringMessageTransformer messageTransformer,
            GetAllFollowsForFollowingApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.FollowingId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForFollowingId(
            IStringMessageTransformer messageTransformer,
            GetFollowByIdApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.FollowingId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForFollowingId(
            IStringMessageTransformer messageTransformer,
            AddFollowApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Body.FollowingId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForFollowingId(
            IStringMessageTransformer messageTransformer,
            DeleteFollowApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.FollowingId,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForFollowingName(
            IStringMessageTransformer messageTransformer,
            GetAllFollowsApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.FollowingName,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForFollowerName(
            IStringMessageTransformer messageTransformer,
            GetAllFollowsForFollowingApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.FollowerName,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForPage(
            IIntMessageTransformer messageTransformer,
            GetAllFollowsApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Page,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForPage(
            IIntMessageTransformer messageTransformer,
            GetAllFollowsForFollowingApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Page,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForPageSize(
            IIntMessageTransformer messageTransformer,
            GetAllFollowsApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.PageSize,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForPageSize(
            IIntMessageTransformer messageTransformer,
            GetAllFollowsForFollowingApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.PageSize,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForSortOrder(
            IEnumMessageTransformer<CommonSortOrder> messageTransformer,
            GetAllFollowsApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.SortOrder,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForSortOrder(
            IEnumMessageTransformer<CommonSortOrder> messageTransformer,
            GetAllFollowsForFollowingApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.SortOrder,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForSortTerm(
            IEnumMessageTransformer<FollowsSortTerm> messageTransformer,
            GetAllFollowsApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.SortTerm,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForSortTerm(
            IEnumMessageTransformer<FollowsForFollowingSortTerm> messageTransformer,
            GetAllFollowsForFollowingApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.SortTerm,
                messageTransformer,
                request);
        }
    }
}
