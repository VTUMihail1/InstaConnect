using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenFluent : IMongoDbFluent<RefreshToken>
{
	public IRefreshTokenFluent Match(RefreshTokenId filter);
	public IRefreshTokenFluent ApplyIncludes(RefreshTokenInclude? include);
}
