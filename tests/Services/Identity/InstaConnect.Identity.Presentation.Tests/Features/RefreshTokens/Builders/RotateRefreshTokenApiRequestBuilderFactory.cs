namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Builders;

public class RotateRefreshTokenApiRequestBuilderFactory
{
	public RotateRefreshTokenApiRequestBuilder Create(RefreshToken refreshToken)
	{
		return new(refreshToken);
	}
}
