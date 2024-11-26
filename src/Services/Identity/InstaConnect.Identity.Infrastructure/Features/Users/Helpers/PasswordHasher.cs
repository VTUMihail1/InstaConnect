using InstaConnect.Identity.Data.Features.Users.Abstractions;
using InstaConnect.Identity.Data.Features.Users.Models;

namespace InstaConnect.Identity.Data.Features.Users.Helpers;

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
