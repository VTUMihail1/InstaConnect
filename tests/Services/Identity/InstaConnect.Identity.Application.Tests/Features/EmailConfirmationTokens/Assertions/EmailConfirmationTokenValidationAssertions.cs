namespace InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenValidationAssertions
{
    extension(TestValidationResult<VerifyEmailConfirmationTokenCommandRequest> result)
    {
        public void ShouldHaveValidationErrorForId(
            IStringMessageTransformer messageTransformer,
            VerifyEmailConfirmationTokenCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
        }

        public void ShouldHaveValidationErrorForValue(
            IStringMessageTransformer messageTransformer,
            VerifyEmailConfirmationTokenCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Value, messageTransformer, request);
        }
    }

    extension(TestValidationResult<AddEmailConfirmationTokenCommandRequest> result)
    {
        public void ShouldHaveValidationErrorForName(
            IStringMessageTransformer messageTransformer,
            AddEmailConfirmationTokenCommandRequest request)
        {
            result.ShouldHaveValidationErrorForProperty(p => p.Name, messageTransformer, request);
        }
    }
}
