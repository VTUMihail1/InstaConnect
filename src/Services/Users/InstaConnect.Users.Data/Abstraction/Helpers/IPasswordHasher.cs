using InstaConnect.Users.Data.Helpers;

namespace InstaConnect.Users.Business.Abstractions;
public interface IPasswordHasher
{
    PasswordHashResultDTO Hash(string password);
    bool Verify(string password, string passwordHash);
}