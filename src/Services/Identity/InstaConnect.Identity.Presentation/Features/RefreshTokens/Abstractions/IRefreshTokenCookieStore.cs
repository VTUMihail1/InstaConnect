namespace InstaConnect.Identity.Presentation.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenCookieStore
{
	public GetRefreshTokenCookieApiResponse? Get();

	public void Set(SetRefreshTokenCookieApiRequest request);

	public void Delete();
}
