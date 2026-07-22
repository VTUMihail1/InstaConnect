namespace InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenValidationAssertions
{
	extension(TestValidationResult<VerifyEmailConfirmationTokenCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			VerifyEmailConfirmationTokenCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForValue(
			VerifyEmailConfirmationTokenCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Value, messageTransformer);
		}
	}

	extension(TestValidationResult<AddEmailConfirmationTokenCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForName(
			AddEmailConfirmationTokenCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Name, messageTransformer);
		}
	}
}
