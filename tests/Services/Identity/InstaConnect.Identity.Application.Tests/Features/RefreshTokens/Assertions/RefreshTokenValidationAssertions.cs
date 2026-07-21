namespace InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenValidationAssertions
{
	extension(TestValidationResult<DeleteCurrentRefreshTokenCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			IStringMessageTransformer messageTransformer,
			DeleteCurrentRefreshTokenCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForValue(
			IStringMessageTransformer messageTransformer,
			DeleteCurrentRefreshTokenCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Value, messageTransformer);
		}
	}

	extension(TestValidationResult<IssueRefreshTokenCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForName(
			IStringMessageTransformer messageTransformer,
			IssueRefreshTokenCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Name, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPassword(
			IStringMessageTransformer messageTransformer,
			IssueRefreshTokenCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Password, messageTransformer);
		}
	}

	extension(TestValidationResult<RotateRefreshTokenCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			IStringMessageTransformer messageTransformer,
			RotateRefreshTokenCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForValue(
			IStringMessageTransformer messageTransformer,
			RotateRefreshTokenCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(request, p => p.Value, messageTransformer);
		}
	}
}
