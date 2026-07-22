namespace InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenValidationAssertions
{
	extension(TestValidationResult<VerifyForgotPasswordTokenCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			VerifyForgotPasswordTokenCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForValue(
			VerifyForgotPasswordTokenCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Value, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPassword(
			VerifyForgotPasswordTokenCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Password, messageTransformer);
		}

		public void ShouldHaveValidationErrorForConfirmPassword(
			VerifyForgotPasswordTokenCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.ConfirmPassword, messageTransformer);
		}
	}

	extension(TestValidationResult<AddForgotPasswordTokenCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForName(
			AddForgotPasswordTokenCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Name, messageTransformer);
		}
	}
}
