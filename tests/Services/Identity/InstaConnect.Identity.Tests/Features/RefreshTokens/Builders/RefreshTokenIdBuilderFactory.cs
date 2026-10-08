using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Builders;

public class RefreshTokenIdBuilderFactory
{
	public RefreshTokenIdBuilder Create(RefreshTokenId id)
	{
		return new(id);
	}
}
