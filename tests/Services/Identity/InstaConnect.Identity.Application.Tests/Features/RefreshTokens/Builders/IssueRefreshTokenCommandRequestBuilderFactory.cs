namespace InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Builders;

public class IssueRefreshTokenCommandRequestBuilderFactory
{
	public IssueRefreshTokenCommandRequestBuilder Create(User user, string password)
	{
		return new(user, password);
	}
}
