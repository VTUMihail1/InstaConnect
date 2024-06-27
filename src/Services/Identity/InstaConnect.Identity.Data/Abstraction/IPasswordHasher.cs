using InstaConnect.Identity.Data.Models;

namespace InstaConnect.Identity.Data.Abstraction;
public interface IPasswordHasher
{
    PasswordHashResultModel Hash(string password);
    bool Verify(string password, string passwordHash);
}
