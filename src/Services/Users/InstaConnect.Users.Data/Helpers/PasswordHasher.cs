using BCrypt.Net;
using InstaConnect.Users.Business.Abstractions;
using InstaConnect.Users.Data.Helpers;

namespace InstaConnect.Users.Business.Helpers;

public class PasswordHasher : IPasswordHasher
{
    public PasswordHashResultDTO Hash(string password)
    {
        return new PasswordHashResultDTO
        {
            PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(password)
        };
    }

    public bool Verify(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);
    }
}
