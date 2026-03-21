namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Builders;

public class IssueRefreshTokenApiRequestBuilderFactory
{
    public IssueRefreshTokenApiRequestBuilder Create(User user, string password)
    {
        return new(user, password);
    }
}
