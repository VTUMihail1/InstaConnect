using InstaConnect.Follows.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Follows.Domain.Features.Users.Abstractions;
public interface IUserWriteRepository
{
    void Add(User user);
    void Delete(User user);
    Task<User?> GetByIdAsync(string id, CancellationToken cancellationToken);
    void Update(User user);
}
