namespace InstaConnect.Identity.Domain.Features.Common.Helpers;

public interface IPasswordHasher
{
    string Hash(string password);

    bool IsMatch(string password, string passwordHash);

    bool IsMismatch(string password, string passwordHash);
}
