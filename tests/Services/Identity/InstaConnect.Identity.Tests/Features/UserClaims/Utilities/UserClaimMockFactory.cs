using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Domain.Features.UserClaims.Helpers;

namespace InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

public static class UserClaimMockFactory
{
	public static IUserClaimIncludeBuilderFactory CreateIncludeBuilderFactory()
	{
		return new UserClaimIncludeBuilderFactory(new UserClaimIncludeDescriptorFactory());
	}
}
