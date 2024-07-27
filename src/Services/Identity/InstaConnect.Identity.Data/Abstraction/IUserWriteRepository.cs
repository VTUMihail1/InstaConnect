using InstaConnect.Identity.Data.Models.Entities;
using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Identity.Data.Abstraction;

public interface IUserWriteRepository : IBaseWriteRepository<User>
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);

    Task<User?> GetByNameAsync(string name, CancellationToken cancellationToken);

    Task ConfirmEmailAsync(string id, CancellationToken cancellationToken);

    Task ResetPasswordAsync(string id, string passwordHash, CancellationToken cancellationToken);
}
