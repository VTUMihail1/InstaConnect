namespace InstaConnect.Identity.Application.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenValidationAssertions
{
	extension(TestValidationResult<VerifyEmailConfirmationTokenCommandRequest> response)
	{
		public void ShouldHaveValidationErrorForId(
			VerifyEmailConfirmationTokenCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForValue(
			VerifyEmailConfirmationTokenCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Value, messageTransformer);
		}
	}

	extension(TestValidationResult<AddEmailConfirmationTokenCommandRequest> response)
	{
		public void ShouldHaveValidationErrorForName(
			AddEmailConfirmationTokenCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Name, messageTransformer);
		}
	}
}
