namespace InstaConnect.Identity.Presentation.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenCookieStore
{
    void Set(SetRefreshTokenCookieRequest request);

    void Delete();
}
