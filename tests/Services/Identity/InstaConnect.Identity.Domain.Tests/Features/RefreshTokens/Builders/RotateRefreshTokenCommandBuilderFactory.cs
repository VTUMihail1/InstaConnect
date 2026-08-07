namespace InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Builders;

public class RotateRefreshTokenCommandBuilderFactory
{
	public RotateRefreshTokenCommandBuilder Create(RefreshToken refreshToken)
	{
		return new(refreshToken);
	}
}
