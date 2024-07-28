using InstaConnect.Identity.Data.Abstraction;
using InstaConnect.Identity.Data.Models;

namespace InstaConnect.Identity.Data.Helpers;

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
