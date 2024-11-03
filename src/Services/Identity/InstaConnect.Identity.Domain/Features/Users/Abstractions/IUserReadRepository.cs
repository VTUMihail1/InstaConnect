using InstaConnect.Identity.Data.Features.Users.Models.Entitites;
using InstaConnect.Identity.Data.Features.Users.Models.Filters;
using InstaConnect.Shared.Data.Models.Pagination;

namespace InstaConnect.Identity.Data.Features.Users.Abstractions;
public interface IUserReadRepository
{
    Task<PaginationList<User>> GetAllAsync(UserCollectionReadQuery query, CancellationToken cancellationToken);
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);
    Task<User?> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<User?> GetByNameAsync(string name, CancellationToken cancellationToken);
}
