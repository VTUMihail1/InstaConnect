namespace InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenValidationAssertions
{
	extension(TestValidationResult<VerifyForgotPasswordTokenCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			IStringMessageTransformer messageTransformer,
			VerifyForgotPasswordTokenCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForValue(
			IStringMessageTransformer messageTransformer,
			VerifyForgotPasswordTokenCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Value, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPassword(
			IStringMessageTransformer messageTransformer,
			VerifyForgotPasswordTokenCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Password, messageTransformer);
		}

		public void ShouldHaveValidationErrorForConfirmPassword(
			IStringMessageTransformer messageTransformer,
			VerifyForgotPasswordTokenCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.ConfirmPassword, messageTransformer);
		}
	}

	extension(TestValidationResult<AddForgotPasswordTokenCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForName(
			IStringMessageTransformer messageTransformer,
			AddForgotPasswordTokenCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Name, messageTransformer);
		}
	}
}
