using InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Helpers;

namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenMockFactory
{
	public static IRefreshTokenIncludeBuilderFactory CreateIncludeBuilderFactory()
	{
		return new RefreshTokenIncludeBuilderFactory(new RefreshTokenIncludeDescriptorFactory());
	}
}
