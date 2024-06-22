using BCrypt.Net;
using InstaConnect.Users.Data.Abstraction;
using InstaConnect.Users.Data.Models;

namespace InstaConnect.Users.Data.Helpers;

public class PasswordHasher : IPasswordHasher
{
    public PasswordHashResultModel Hash(string password)
    {
        return new PasswordHashResultModel
        {
            PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(password)
        };
    }

    public bool Verify(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);
    }
}
