using InstaConnect.Users.Data.Models;

namespace InstaConnect.Users.Data.Abstraction;
public interface IPasswordHasher
{
    PasswordHashResultDTO Hash(string password);
    bool Verify(string password, string passwordHash);
}