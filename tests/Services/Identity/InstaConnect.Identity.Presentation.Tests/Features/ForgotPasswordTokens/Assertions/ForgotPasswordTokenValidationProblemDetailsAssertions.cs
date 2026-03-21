using InstaConnect.Common.Presentation.Models;

namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenValidationProblemDetailsAssertions
{
    extension(ApplicationProblemDetails problemDetails)
    {
        public void ShouldSatisfyInvalidValidationForName(
            IStringMessageTransformer messageTransformer,
            AddForgotPasswordTokenCommandRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Name,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForId(
            IStringMessageTransformer messageTransformer,
            VerifyForgotPasswordTokenCommandRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Id,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForValue(
            IStringMessageTransformer messageTransformer,
            VerifyForgotPasswordTokenCommandRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Value,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForPassword(
            IStringMessageTransformer messageTransformer,
            VerifyForgotPasswordTokenCommandRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.Password,
                messageTransformer,
                request);
        }

        public void ShouldSatisfyInvalidValidationForConfirmPassword(
            IStringMessageTransformer messageTransformer,
            VerifyForgotPasswordTokenCommandRequest request)
        {
            problemDetails.ShouldSatisfyInvalidValidation(
                p => p.ConfirmPassword,
                messageTransformer,
                request);
        }
    }
}
