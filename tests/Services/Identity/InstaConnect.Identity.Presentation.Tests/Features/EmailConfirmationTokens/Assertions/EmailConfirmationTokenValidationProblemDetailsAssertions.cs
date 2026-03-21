using InstaConnect.Common.Presentation.Models;

namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenValidationProblemDetailsAssertions
{
    extension(ApplicationProblemDetails problemDetails)
    {
        public void ShouldSatisfyInvalidValidationForName(
            IStringMessageTransformer messageTransformer,
            AddEmailConfirmationTokenCommandRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Name,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForId(
            IStringMessageTransformer messageTransformer,
            VerifyEmailConfirmationTokenCommandRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Id,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForValue(
            IStringMessageTransformer messageTransformer,
            VerifyEmailConfirmationTokenCommandRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Value,
                messageTransformer,
                request);
        }
    }
}
