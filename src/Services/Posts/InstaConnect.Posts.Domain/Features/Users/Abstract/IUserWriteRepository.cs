using InstaConnect.Posts.Domain.Features.Users.Models.Entitites;

namespace InstaConnect.Posts.Domain.Features.Users.Abstract;
public interface IUserWriteRepository
{
    void Add(User user);
    void Delete(User user);
    Task<User?> GetByIdAsync(string id, CancellationToken cancellationToken);
    void Update(User user);
}
