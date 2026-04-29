using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;

namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenValidationProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyInvalidValidationForName(
			IStringMessageTransformer messageTransformer,
			AddForgotPasswordTokenApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Name,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForId(
			IStringMessageTransformer messageTransformer,
			VerifyForgotPasswordTokenApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Id,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForValue(
			IStringMessageTransformer messageTransformer,
			VerifyForgotPasswordTokenApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Value,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForPassword(
			IStringMessageTransformer messageTransformer,
			VerifyForgotPasswordTokenApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Body.Password,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForConfirmPassword(
			IStringMessageTransformer messageTransformer,
			VerifyForgotPasswordTokenApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Body.ConfirmPassword,
				messageTransformer,
				request);
		}
	}
}
