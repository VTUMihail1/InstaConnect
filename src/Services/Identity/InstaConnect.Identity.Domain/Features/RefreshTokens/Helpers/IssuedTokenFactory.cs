namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Helpers;

internal class IssuedTokenFactory : ISessionTokenFactory
{
    public SessionToken Create(RefreshToken refreshToken, AccessToken accessToken)
    {
        var issuedTokens = new SessionToken(
            refreshToken,
            accessToken);

        return issuedTokens;
    }
}
