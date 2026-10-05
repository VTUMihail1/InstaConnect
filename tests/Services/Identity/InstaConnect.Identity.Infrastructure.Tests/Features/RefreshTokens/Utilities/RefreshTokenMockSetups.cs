using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenMockSetups
{
	extension(IRefreshTokenCollection collection)
	{
		public void SetupAggregateFluent(
			RefreshTokenId id,
			IRefreshTokenFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}
	}

	extension(IRefreshTokenFluent fluent)
	{
		public void SetupApplyIncludes(
			RefreshTokenId id,
			RefreshTokenInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupMatch(RefreshTokenId id)
		{
			fluent.Match(id).ReturnsResponse(fluent);
		}

		public void SetupFirstOrDefaultAsync(
			RefreshTokenId id,
			RefreshToken refreshToken,
			CancellationToken cancellationToken)
		{
			fluent.FirstOrDefaultAsync(cancellationToken).ReturnsTaskResponse(refreshToken);
		}
	}
}
