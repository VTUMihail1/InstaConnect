using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Infrastructure.Features.Common.Helpers;

namespace InstaConnect.Identity.Tests.Features.Common.Utilities;

public static class IdentityMockFactory
{
	public static IPasswordHasher CreatePasswordHasher()
	{
		return new PasswordHasher();
	}
}
