using InstaConnect.Identity.Domain.Helpers;

namespace InstaConnect.Identity.Infrastructure.Helpers;

public class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool IsMatch(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }

    public bool IsMismatch(string password, string passwordHash)
    {
        return !IsMatch(password, passwordHash);
    }
}
