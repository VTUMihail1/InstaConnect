using InstaConnect.Identity.Data.Models.Entities;
using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Identity.Data.Abstraction;

public interface IUserReadRepository : IBaseReadRepository<User>
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);

    Task<User?> GetByNameAsync(string name, CancellationToken cancellationToken);
}
