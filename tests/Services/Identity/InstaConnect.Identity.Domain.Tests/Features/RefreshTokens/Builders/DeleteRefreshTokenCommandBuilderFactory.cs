namespace InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Builders;

public class DeleteRefreshTokenCommandBuilderFactory
{
	public DeleteRefreshTokenCommandBuilder Create(RefreshToken refreshToken)
	{
		return new(refreshToken);
	}
}
