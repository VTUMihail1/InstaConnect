using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Helpers.Collections;

internal class RefreshTokenFluent : MongoDbFluent<RefreshToken>, IRefreshTokenFluent
{
	private readonly IRefreshTokenIncluderFactory _includerFactory;

	public RefreshTokenFluent(
		IAggregateFluent<RefreshToken> fluent,
		IRefreshTokenIncluderFactory includerFactory) : base(fluent)
	{
		_includerFactory = includerFactory;
	}

	public IRefreshTokenFluent ApplyIncludes(RefreshTokenInclude include)
	{
		ApplyIncludes(_includerFactory, include);

		return this;
	}

	public IRefreshTokenFluent Match(RefreshTokenId filter)
	{
		Match(filter.GetFilter());

		return this;
	}
}
