using InstaConnect.Identity.Data.Features.Users.Models;

namespace InstaConnect.Identity.Data.Features.Users.Abstractions;
public interface IPasswordHasher
{
    PasswordHashResultModel Hash(string password);
    bool Verify(string password, string passwordHash);
}
