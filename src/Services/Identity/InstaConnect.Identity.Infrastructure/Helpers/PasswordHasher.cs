using InstaConnect.Identity.Domain.Helpers;

namespace InstaConnect.Identity.Infrastructure.Helpers;

internal class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
    }

    public bool IsMatch(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);
    }

    public bool IsMismatch(string password, string passwordHash)
    {
        return !IsMatch(password, passwordHash);
    }
}
