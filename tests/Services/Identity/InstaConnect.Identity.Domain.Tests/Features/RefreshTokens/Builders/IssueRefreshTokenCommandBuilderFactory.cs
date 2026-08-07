namespace InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Builders;

public class IssueRefreshTokenCommandBuilderFactory
{
	public IssueRefreshTokenCommandBuilder Create(User user, string password)
	{
		return new(user, password);
	}
}
