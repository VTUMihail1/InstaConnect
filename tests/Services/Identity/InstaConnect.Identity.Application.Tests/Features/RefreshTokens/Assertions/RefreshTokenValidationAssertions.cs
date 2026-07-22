namespace InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenValidationAssertions
{
	extension(TestValidationResult<DeleteCurrentRefreshTokenCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			DeleteCurrentRefreshTokenCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForValue(
			DeleteCurrentRefreshTokenCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Value, messageTransformer);
		}
	}

	extension(TestValidationResult<IssueRefreshTokenCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForName(
			IssueRefreshTokenCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Name, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPassword(
			IssueRefreshTokenCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Password, messageTransformer);
		}
	}

	extension(TestValidationResult<RotateRefreshTokenCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			RotateRefreshTokenCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForValue(
			RotateRefreshTokenCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Value, messageTransformer);
		}
	}
}
