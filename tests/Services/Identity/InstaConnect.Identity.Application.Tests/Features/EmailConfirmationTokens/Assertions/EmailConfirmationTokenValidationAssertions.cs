namespace InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenValidationAssertions
{
	extension(TestValidationResult<VerifyEmailConfirmationTokenCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			IStringMessageTransformer messageTransformer,
			VerifyEmailConfirmationTokenCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForValue(
			IStringMessageTransformer messageTransformer,
			VerifyEmailConfirmationTokenCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Value, messageTransformer);
		}
	}

	extension(TestValidationResult<AddEmailConfirmationTokenCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForName(
			IStringMessageTransformer messageTransformer,
			AddEmailConfirmationTokenCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Name, messageTransformer);
		}
	}
}
