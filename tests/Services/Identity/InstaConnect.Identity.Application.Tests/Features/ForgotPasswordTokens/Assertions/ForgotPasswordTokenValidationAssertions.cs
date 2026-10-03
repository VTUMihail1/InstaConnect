namespace InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenValidationAssertions
{
	extension(TestValidationResult<VerifyForgotPasswordTokenCommandRequest> response)
	{
		public void ShouldHaveValidationErrorForId(
			VerifyForgotPasswordTokenCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForValue(
			VerifyForgotPasswordTokenCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Value, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPassword(
			VerifyForgotPasswordTokenCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Password, messageTransformer);
		}

		public void ShouldHaveValidationErrorForConfirmPassword(
			VerifyForgotPasswordTokenCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.ConfirmPassword, messageTransformer);
		}
	}

	extension(TestValidationResult<AddForgotPasswordTokenCommandRequest> response)
	{
		public void ShouldHaveValidationErrorForName(
			AddForgotPasswordTokenCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Name, messageTransformer);
		}
	}
}
