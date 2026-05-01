namespace InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Builders;

public class RotateRefreshTokenCommandRequestBuilderFactory
{
	public RotateRefreshTokenCommandRequestBuilder Create(RefreshToken refreshToken)
	{
		return new(refreshToken);
	}
}
