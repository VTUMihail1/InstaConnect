using InstaConnect.Identity.Domain.Features.Users.Models;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers;

internal class PasswordHasher : IPasswordHasher
{
    public PasswordHashResultModel Hash(string password)
    {
        return new PasswordHashResultModel(BCrypt.Net.BCrypt.EnhancedHashPassword(password));
    }

    public bool Verify(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);
    }
}
