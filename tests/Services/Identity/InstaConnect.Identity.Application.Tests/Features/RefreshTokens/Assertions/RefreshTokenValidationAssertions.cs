namespace InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenValidationAssertions
{
	extension(TestValidationResult<DeleteCurrentRefreshTokenCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			IStringMessageTransformer messageTransformer,
			DeleteCurrentRefreshTokenCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForValue(
			IStringMessageTransformer messageTransformer,
			DeleteCurrentRefreshTokenCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Value, messageTransformer, request);
		}
	}

	extension(TestValidationResult<IssueRefreshTokenCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForName(
			IStringMessageTransformer messageTransformer,
			IssueRefreshTokenCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Name, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForPassword(
			IStringMessageTransformer messageTransformer,
			IssueRefreshTokenCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Password, messageTransformer, request);
		}
	}

	extension(TestValidationResult<RotateRefreshTokenCommandRequest> result)
	{
		public void ShouldHaveValidationErrorForId(
			IStringMessageTransformer messageTransformer,
			RotateRefreshTokenCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Id, messageTransformer, request);
		}

		public void ShouldHaveValidationErrorForValue(
			IStringMessageTransformer messageTransformer,
			RotateRefreshTokenCommandRequest request)
		{
			result.ShouldHaveValidationErrorForProperty(p => p.Value, messageTransformer, request);
		}
	}
}
