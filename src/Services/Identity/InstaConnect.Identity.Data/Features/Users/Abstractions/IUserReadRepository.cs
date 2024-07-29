using InstaConnect.Identity.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Identity.Data.Features.Users.Abstractions;

public interface IUserReadRepository : IBaseReadRepository<User>
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);

    Task<User?> GetByNameAsync(string name, CancellationToken cancellationToken);
}
