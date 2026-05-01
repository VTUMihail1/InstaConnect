using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;

namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenValidationProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyInvalidValidationForName(
			IStringMessageTransformer messageTransformer,
			AddEmailConfirmationTokenApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Name,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForId(
			IStringMessageTransformer messageTransformer,
			VerifyEmailConfirmationTokenApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Id,
				messageTransformer,
				request);
		}

		public void ShouldSatisfyInvalidValidationForValue(
			IStringMessageTransformer messageTransformer,
			VerifyEmailConfirmationTokenApiRequest request)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				p => p.Value,
				messageTransformer,
				request);
		}
	}
}
