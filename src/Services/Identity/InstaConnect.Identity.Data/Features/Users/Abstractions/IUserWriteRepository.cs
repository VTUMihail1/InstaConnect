using InstaConnect.Identity.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Identity.Data.Features.Users.Abstractions;

public interface IUserWriteRepository : IBaseWriteRepository<User>
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);

    Task<User?> GetByNameAsync(string name, CancellationToken cancellationToken);

    Task ConfirmEmailAsync(string id, CancellationToken cancellationToken);

    Task ResetPasswordAsync(string id, string passwordHash, CancellationToken cancellationToken);
}
