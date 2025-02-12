using InstaConnect.Identity.Domain.Features.Users.Models;

namespace InstaConnect.Identity.Domain.Features.Users.Abstractions;
public interface IPasswordHasher
{
    PasswordHashResultModel Hash(string password);
    bool Verify(string password, string passwordHash);
}
