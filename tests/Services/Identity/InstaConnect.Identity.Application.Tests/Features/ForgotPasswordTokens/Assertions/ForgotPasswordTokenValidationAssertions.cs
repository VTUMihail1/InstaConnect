namespace InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenValidationAssertions
{
    extension(TestValidationResult<VerifyForgotPasswordTokenCommandRequest> result)
    {
        public void ShouldHaveValidationErrorForId(
            IStringMessageTransformer messageTransformer,
            VerifyForgotPasswordTokenCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForValue(
            IStringMessageTransformer messageTransformer,
            VerifyForgotPasswordTokenCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Value, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForPassword(
            IStringMessageTransformer messageTransformer,
            VerifyForgotPasswordTokenCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Password, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForConfirmPassword(
            IStringMessageTransformer messageTransformer,
            VerifyForgotPasswordTokenCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.ConfirmPassword, messageTransformer, request);
        }
    }

    extension(TestValidationResult<AddForgotPasswordTokenCommandRequest> result)
    {
        public void ShouldHaveValidationErrorForName(
            IStringMessageTransformer messageTransformer,
            AddForgotPasswordTokenCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Name, messageTransformer, request);
        }
    }
}
