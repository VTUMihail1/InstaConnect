using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;
using InstaConnect.Users.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Users.Domain.Features.Users.Abstractions;

public interface IUserRepository
{
    Task<UserCollection> GetAllAsync(GetAllUsersQuery query, CancellationToken cancellationToken);

    Task<User?> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<User?> GetByNameAsync(string name, CancellationToken cancellationToken);
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);

    void Add(User user);

    void Update(User user);

    void Delete(User user);
}
