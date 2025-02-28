using InstaConnect.Common.Domain.Models.Pagination;
using InstaConnect.Identity.Domain.Features.Users.Models.Entities;
using InstaConnect.Identity.Domain.Features.Users.Models.Filters;

namespace InstaConnect.Identity.Domain.Features.Users.Abstractions;
public interface IUserReadRepository
{
    Task<PaginationList<User>> GetAllAsync(UserCollectionReadQuery query, CancellationToken cancellationToken);
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);
    Task<User?> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<User?> GetByNameAsync(string name, CancellationToken cancellationToken);
}
