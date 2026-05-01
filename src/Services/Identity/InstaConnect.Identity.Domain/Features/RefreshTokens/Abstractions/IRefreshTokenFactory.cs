namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenFactory
{
	public RefreshToken Create(UserId id);
}
