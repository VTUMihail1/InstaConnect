using InstaConnect.Common.Presentation.Models;

namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenValidationProblemDetailsAssertions
{
    extension(ApplicationProblemDetails problemDetails)
    {
        public void ShouldSatisfyInvalidValidationForName(
            IStringMessageTransformer messageTransformer,
            IssueRefreshTokenCommandRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Name,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForPassword(
            IStringMessageTransformer messageTransformer,
            IssueRefreshTokenCommandRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Password,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForId(
            IStringMessageTransformer messageTransformer,
            DeleteCurrentRefreshTokenCommandRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Id,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForId(
            IStringMessageTransformer messageTransformer,
            RotateRefreshTokenCommandRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Id,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForValue(
            IStringMessageTransformer messageTransformer,
            DeleteCurrentRefreshTokenCommandRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Value,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForValue(
            IStringMessageTransformer messageTransformer,
            RotateRefreshTokenCommandRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Value,
                messageTransformer,
                request);
        }
    }
}
