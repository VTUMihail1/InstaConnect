using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenValidationProblemDetailsAssertions
{
    extension(ApplicationProblemDetails problemDetails)
    {
        public void ShouldSatisfyInvalidValidationForName(
            IStringMessageTransformer messageTransformer,
            IssueRefreshTokenApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Name,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForPassword(
            IStringMessageTransformer messageTransformer,
            IssueRefreshTokenApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Body.Password,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForId(
            IStringMessageTransformer messageTransformer,
            DeleteCurrentRefreshTokenApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Id,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForId(
            IStringMessageTransformer messageTransformer,
            RotateRefreshTokenApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Id,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForValue(
            IStringMessageTransformer messageTransformer,
            DeleteCurrentRefreshTokenApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Value,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForValue(
            IStringMessageTransformer messageTransformer,
            RotateRefreshTokenApiRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Value,
                messageTransformer,
                request);
        }
    }
}
