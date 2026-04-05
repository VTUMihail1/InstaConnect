using InstaConnect.Identity.Domain.Helpers;
using InstaConnect.Identity.Infrastructure.Helpers;

namespace InstaConnect.Identity.Tests.Utilities;

public static class IdentityMockFactory
{
    public static IPasswordHasher CreatePasswordHasher()
    {
        return new PasswordHasher();
    }
}
