using InstaConnect.Identity.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Identity.Domain.Features.Users.Abstractions;
public interface IUserWriteRepository
{
    void Add(User entity);
    Task<bool> AnyAsync(CancellationToken cancellationToken);
    Task ConfirmEmailAsync(string id, CancellationToken cancellationToken);
    void Delete(User entity);
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);
    Task<User?> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<User?> GetByNameAsync(string name, CancellationToken cancellationToken);
    Task ResetPasswordAsync(string id, string passwordHash, CancellationToken cancellationToken);
    void Update(User entity);
}
