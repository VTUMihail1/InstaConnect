using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Domain.Features.Users.Abstractions;
public interface IUserRepository
{

    Task<User?> GetByIdAsync(string id, CancellationToken cancellationToken);

    Task<User?> GetByNameAsync(string name, CancellationToken cancellationToken);

    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);

    void Add(User user);

    void Delete(User user);

    void Update(User user);
}
