namespace InstaConnect.Identity.Presentation.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenCookieStore
{
	public void Set(SetRefreshTokenCookieRequest request);

	public void Delete();
}
